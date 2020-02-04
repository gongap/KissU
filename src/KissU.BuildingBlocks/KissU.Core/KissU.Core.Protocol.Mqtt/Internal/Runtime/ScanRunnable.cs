﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using KissU.Core.Protocol.Mqtt.Internal.Enums;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// ScanRunnable.
    /// Implements the <see cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.Runnable" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.Runnable" />
    public abstract class ScanRunnable : Runnable
    {
        private ConcurrentQueue<SendMqttMessage> _queue = new ConcurrentQueue<SendMqttMessage>();
        /// <summary>
        /// Enqueues the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        public void Enqueue(SendMqttMessage t)
        {
             _queue.Enqueue(t);
        }

        /// <summary>
        /// Enqueues the specified ts.
        /// </summary>
        /// <param name="ts">The ts.</param>
        public void Enqueue(List<SendMqttMessage> ts)
        {
            ts.ForEach(message=> _queue.Enqueue(message));
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public override void Run()
        {
            if (!_queue.IsEmpty)
            {
                List<SendMqttMessage> list = new List<SendMqttMessage>();
                for (; (_queue.TryDequeue(out SendMqttMessage poll));)
                {
                    if (poll.ConfirmStatus != ConfirmStatus.COMPLETE)
                    {
                        list.Add(poll);
                        Execute(poll);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Executes the specified poll.
        /// </summary>
        /// <param name="poll">The poll.</param>
        public abstract void Execute(SendMqttMessage poll);
    }
}
