using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace KissU.Core.Helpers.Utilities
{
    /// <summary>
    /// ������
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    internal interface IStrongBox<T>
    {
        ref T Value { get; }

        bool RunContinuationsAsynchronously { get; set; }
    }

    /// <summary>
    /// ����ѡ��
    /// </summary>
    public enum ContinuationOptions
    {
        None,

        ForceDefaultTaskScheduler
    }

    /// <summary>
    /// Manual Reset Value Task Source.
    /// Implements the
    /// <see
    ///     cref="IStrongBox{ManualResetValueTaskSourceLogic{T}}" />
    /// Implements the <see cref="IValueTaskSource{TResult}" />
    /// Implements the <see cref="IValueTaskSource" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso
    ///     cref="IStrongBox{ManualResetValueTaskSourceLogic{T}}" />
    /// <seealso cref="IValueTaskSource{T}" />
    /// <seealso cref="IValueTaskSource" />
    public class ManualResetValueTaskSource<T> : IStrongBox<ManualResetValueTaskSourceLogic<T>>, IValueTaskSource<T>,
        IValueTaskSource
    {
        private readonly Action _cancellationCallback;
        private ManualResetValueTaskSourceLogic<T> _logic;

        public ManualResetValueTaskSource(ContinuationOptions options = ContinuationOptions.None)
        {
            _logic = new ManualResetValueTaskSourceLogic<T>(this, options);
            _cancellationCallback = SetCanceled;
        }

        public short Version => _logic.Version;

        public bool RunContinuationsAsynchronously { get; set; } = true;

        ref ManualResetValueTaskSourceLogic<T> IStrongBox<ManualResetValueTaskSourceLogic<T>>.Value => ref _logic;

        void IValueTaskSource.GetResult(short token)
        {
            _logic.GetResult(token);
        }

        public T GetResult(short token)
        {
            return _logic.GetResult(token);
        }

        public ValueTaskSourceStatus GetStatus(short token)
        {
            return _logic.GetStatus(token);
        }

        public void OnCompleted(Action<object> continuation, object state, short token,
            ValueTaskSourceOnCompletedFlags flags)
        {
            _logic.OnCompleted(continuation, state, token, flags);
        }

        public bool SetResult(T result)
        {
            lock (_cancellationCallback)
            {
                if (_logic.Completed)
                {
                    return false;
                }

                _logic.SetResult(result);
                return true;
            }
        }

        public void SetException(Exception error)
        {
            if (Monitor.TryEnter(_cancellationCallback))
            {
                if (_logic.Completed)
                {
                    Monitor.Exit(_cancellationCallback);
                    return;
                }

                _logic.SetException(error);
                Monitor.Exit(_cancellationCallback);
            }
        }

        public void SetCanceled()
        {
            SetException(new TaskCanceledException());
        }


        public ValueTask<T> AwaitValue(CancellationToken cancellation)
        {
            var registration = cancellation == CancellationToken.None
                ? (CancellationTokenRegistration?) null
                : cancellation.Register(_cancellationCallback);
            return _logic.AwaitValue(this, registration);
        }

        public ValueTask AwaitVoid(CancellationToken cancellation)
        {
            var registration = cancellation == CancellationToken.None
                ? (CancellationTokenRegistration?) null
                : cancellation.Register(_cancellationCallback);
            return _logic.AwaitVoid(this, registration);
        }

        public void Reset()
        {
            _logic.Reset();
        }
    }

    internal struct ManualResetValueTaskSourceLogic<TResult>
    {
        private static readonly Action<object> s_sentinel = s => throw new InvalidOperationException();

        private readonly IStrongBox<ManualResetValueTaskSourceLogic<TResult>> _parent;
        private readonly ContinuationOptions _options;
        private Action<object> _continuation;
        private object _continuationState;
        private object _capturedContext;
        private ExecutionContext _executionContext;
        private TResult _result;
        private ExceptionDispatchInfo _error;
        private CancellationTokenRegistration? _registration;

        public ManualResetValueTaskSourceLogic(IStrongBox<ManualResetValueTaskSourceLogic<TResult>> parent,
            ContinuationOptions options)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
            _options = options;
            _continuation = null;
            _continuationState = null;
            _capturedContext = null;
            _executionContext = null;
            Completed = false;
            _result = default;
            _error = null;
            Version = 0;
            _registration = null;
        }

        public short Version { get; private set; }

        public bool Completed { get; private set; }

        private void ValidateToken(short token)
        {
            if (token != Version)
            {
                throw new InvalidOperationException();
            }
        }

        public ValueTaskSourceStatus GetStatus(short token)
        {
            ValidateToken(token);

            return
                !Completed ? ValueTaskSourceStatus.Pending :
                _error == null ? ValueTaskSourceStatus.Succeeded :
                _error.SourceException is OperationCanceledException ? ValueTaskSourceStatus.Canceled :
                ValueTaskSourceStatus.Faulted;
        }

        public TResult GetResult(short token)
        {
            ValidateToken(token);

            if (!Completed)
            {
                throw new InvalidOperationException();
            }

            var result = _result;
            var error = _error;
            Reset();

            error?.Throw();
            return result;
        }

        public void Reset()
        {
            Version++;

            _registration?.Dispose();

            Completed = false;
            _continuation = null;
            _continuationState = null;
            _result = default;
            _error = null;
            _executionContext = null;
            _capturedContext = null;
            _registration = null;
        }

        public void OnCompleted(Action<object> continuation, object state, short token,
            ValueTaskSourceOnCompletedFlags flags)
        {
            if (continuation == null)
            {
                throw new ArgumentNullException(nameof(continuation));
            }

            ValidateToken(token);


            if ((flags & ValueTaskSourceOnCompletedFlags.FlowExecutionContext) != 0)
            {
                _executionContext = ExecutionContext.Capture();
            }

            if ((flags & ValueTaskSourceOnCompletedFlags.UseSchedulingContext) != 0)
            {
                var sc = SynchronizationContext.Current;
                if (sc != null && sc.GetType() != typeof(SynchronizationContext))
                {
                    _capturedContext = sc;
                }
                else
                {
                    var ts = TaskScheduler.Current;
                    if (ts != TaskScheduler.Default)
                    {
                        _capturedContext = ts;
                    }
                }
            }

            _continuationState = state;
            if (Interlocked.CompareExchange(ref _continuation, continuation, null) != null)
            {
                _executionContext = null;

                var cc = _capturedContext;
                _capturedContext = null;

                switch (cc)
                {
                    case null:
                        Task.Factory.StartNew(continuation, state, CancellationToken.None,
                            TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
                        break;

                    case SynchronizationContext sc:
                        sc.Post(s =>
                        {
                            var tuple = (Tuple<Action<object>, object>) s;
                            tuple.Item1(tuple.Item2);
                        }, Tuple.Create(continuation, state));
                        break;

                    case TaskScheduler ts:
                        Task.Factory.StartNew(continuation, state, CancellationToken.None,
                            TaskCreationOptions.DenyChildAttach, ts);
                        break;
                }
            }
        }

        public void SetResult(TResult result)
        {
            _result = result;
            SignalCompletion();
        }

        public void SetException(Exception error)
        {
            _error = ExceptionDispatchInfo.Capture(error);
            SignalCompletion();
        }

        private void SignalCompletion()
        {
            if (Completed)
            {
                throw new InvalidOperationException("Double completion of completion source is prohibited");
            }

            Completed = true;

            if (Interlocked.CompareExchange(ref _continuation, s_sentinel, null) != null)
            {
                if (_executionContext != null)
                {
                    ExecutionContext.Run(
                        _executionContext,
                        s => ((IStrongBox<ManualResetValueTaskSourceLogic<TResult>>) s).Value.InvokeContinuation(),
                        _parent ?? throw new InvalidOperationException());
                }
                else
                {
                    InvokeContinuation();
                }
            }
        }

        private void InvokeContinuation()
        {
            var cc = _capturedContext;
            _capturedContext = null;

            if (_options == ContinuationOptions.ForceDefaultTaskScheduler)
            {
                cc = TaskScheduler.Default;
            }

            switch (cc)
            {
                case null:
                    if (_parent.RunContinuationsAsynchronously)
                    {
                        var c = _continuation;
                        if (_executionContext != null)
                        {
                            ThreadPool.QueueUserWorkItem(s => c(s), _continuationState);
                        }
                        else
                        {
                            ThreadPool.UnsafeQueueUserWorkItem(s => c(s), _continuationState);
                        }
                    }
                    else
                    {
                        _continuation(_continuationState);
                    }

                    break;

                case SynchronizationContext sc:
                    sc.Post(s =>
                        {
                            ref var logicRef = ref ((IStrongBox<ManualResetValueTaskSourceLogic<TResult>>) s).Value;
                            logicRef._continuation(logicRef._continuationState);
                        }, _parent ?? throw new InvalidOperationException());
                    break;

                case TaskScheduler ts:
                    Task.Factory.StartNew(_continuation, _continuationState, CancellationToken.None,
                        TaskCreationOptions.DenyChildAttach, ts);
                    break;
            }
        }

        public ValueTask<T> AwaitValue<T>(IValueTaskSource<T> source, CancellationTokenRegistration? registration)
        {
            _registration = registration;
            return new ValueTask<T>(source, Version);
        }

        public ValueTask AwaitVoid(IValueTaskSource source, CancellationTokenRegistration? registration)
        {
            _registration = registration;
            return new ValueTask(source, Version);
        }
    }
}