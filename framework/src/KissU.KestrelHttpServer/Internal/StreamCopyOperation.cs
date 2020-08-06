using System;
using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace KissU.KestrelHttpServer.Internal
{
    /// <summary>
    /// StreamCopyOperation.
    /// </summary>
    internal class StreamCopyOperation
    {
        private const int DefaultBufferSize = 1024 * 16;
        private readonly byte[] _buffer;
        private readonly Stream _destination;
        private readonly AsyncCallback _readCallback;
        private readonly Stream _source;

        private readonly TaskCompletionSource<object> _tcs;
        private readonly AsyncCallback _writeCallback;

        private long? _bytesRemaining;
        private readonly CancellationToken _cancel;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamCopyOperation" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="bytesRemaining">The bytes remaining.</param>
        /// <param name="cancel">The cancel.</param>
        internal StreamCopyOperation(Stream source, Stream destination, long? bytesRemaining, CancellationToken cancel)
            : this(source, destination, bytesRemaining, DefaultBufferSize, cancel)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamCopyOperation" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="bytesRemaining">The bytes remaining.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="cancel">The cancel.</param>
        internal StreamCopyOperation(Stream source, Stream destination, long? bytesRemaining, int bufferSize,
            CancellationToken cancel)
            : this(source, destination, bytesRemaining, new byte[bufferSize], cancel)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamCopyOperation" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="bytesRemaining">The bytes remaining.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="cancel">The cancel.</param>
        internal StreamCopyOperation(Stream source, Stream destination, long? bytesRemaining, byte[] buffer,
            CancellationToken cancel)
        {
            Contract.Assert(source != null);
            Contract.Assert(destination != null);
            Contract.Assert(!bytesRemaining.HasValue || bytesRemaining.Value >= 0);
            Contract.Assert(buffer != null);

            _source = source;
            _destination = destination;
            _bytesRemaining = bytesRemaining;
            _cancel = cancel;
            _buffer = buffer;

            _tcs = new TaskCompletionSource<object>();
            _readCallback = ReadCallback;
            _writeCallback = WriteCallback;
        }

        /// <summary>
        /// copy to as an asynchronous operation.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="count">The count.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="cancel">The cancel.</param>
        public static async Task CopyToAsync(Stream source, Stream destination, long? count, int bufferSize,
            CancellationToken cancel)
        {
            var bytesRemaining = count;

            var buffer = ArrayPool<byte>.Shared.Rent(bufferSize);
            try
            {
                Debug.Assert(source != null);
                Debug.Assert(destination != null);
                Debug.Assert(!bytesRemaining.HasValue || bytesRemaining.Value >= 0);
                Debug.Assert(buffer != null);

                while (true)
                {
                    if (bytesRemaining.HasValue && bytesRemaining.Value <= 0)
                    {
                        return;
                    }

                    cancel.ThrowIfCancellationRequested();

                    var readLength = buffer.Length;
                    if (bytesRemaining.HasValue)
                    {
                        readLength = (int) Math.Min(bytesRemaining.Value, readLength);
                    }

                    var read = await source.ReadAsync(buffer, 0, readLength, cancel);

                    if (bytesRemaining.HasValue)
                    {
                        bytesRemaining -= read;
                    }

                    if (read <= 0)
                    {
                        return;
                    }

                    cancel.ThrowIfCancellationRequested();

                    destination.Write(buffer, 0, read);
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns>Task.</returns>
        internal Task Start()
        {
            ReadNextSegment();
            return _tcs.Task;
        }

        private void Complete()
        {
            _tcs.TrySetResult(null);
        }

        private bool CheckCancelled()
        {
            if (_cancel.IsCancellationRequested)
            {
                _tcs.TrySetCanceled();
                return true;
            }

            return false;
        }

        private void Fail(Exception ex)
        {
            _tcs.TrySetException(ex);
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Redirecting")]
        private void ReadNextSegment()
        {
            // The natural end of the range.
            if (_bytesRemaining.HasValue && _bytesRemaining.Value <= 0)
            {
                Complete();
                return;
            }

            if (CheckCancelled())
            {
                return;
            }

            try
            {
                var readLength = _buffer.Length;
                if (_bytesRemaining.HasValue)
                {
                    readLength = (int) Math.Min(_bytesRemaining.Value, readLength);
                }

                var async = _source.BeginRead(_buffer, 0, readLength, _readCallback, null);

                if (async.CompletedSynchronously)
                {
                    var read = _source.EndRead(async);
                    WriteToOutputStream(read);
                }
            }
            catch (Exception ex)
            {
                Fail(ex);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Redirecting")]
        private void ReadCallback(IAsyncResult async)
        {
            if (async.CompletedSynchronously)
            {
                return;
            }

            try
            {
                var read = _source.EndRead(async);
                WriteToOutputStream(read);
            }
            catch (Exception ex)
            {
                Fail(ex);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Redirecting")]
        private void WriteToOutputStream(int count)
        {
            if (_bytesRemaining.HasValue)
            {
                _bytesRemaining -= count;
            }

            if (count == 0)
            {
                Complete();
                return;
            }

            if (CheckCancelled())
            {
                return;
            }

            try
            {
                var async = _destination.BeginWrite(_buffer, 0, count, _writeCallback, null);
                if (async.CompletedSynchronously)
                {
                    _destination.EndWrite(async);
                    ReadNextSegment();
                }
            }
            catch (Exception ex)
            {
                Fail(ex);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Redirecting")]
        private void WriteCallback(IAsyncResult async)
        {
            if (async.CompletedSynchronously)
            {
                return;
            }

            try
            {
                _destination.EndWrite(async);
                ReadNextSegment();
            }
            catch (Exception ex)
            {
                Fail(ex);
            }
        }
    }
}