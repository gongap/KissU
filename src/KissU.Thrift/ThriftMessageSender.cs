using System;
using System.Net;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Transport.Client;

namespace KissU.Thrift
{
    public abstract class ThriftMessageSender
    {
        private readonly ITransportMessageEncoder _transportMessageEncoder;

        protected ThriftMessageSender(ITransportMessageEncoder transportMessageEncoder)
        {
            _transportMessageEncoder = transportMessageEncoder;
        }

        protected byte[] GetBinary(TransportMessage message)
        {
            return _transportMessageEncoder.Encode(message);
        }
    }

    public class ThriftMessageClientSender : ThriftMessageSender, IMessageSender, IDisposable
    {
        private readonly TProtocol _protocol;
        private readonly TSocketTransport _transport;

        public ThriftMessageClientSender(ITransportMessageEncoder transportMessageEncoder, TProtocol context) : base(transportMessageEncoder)
        {
            _protocol = context;
            _transport = (TSocketTransport) _protocol.Transport;
        }


        #region Implementation of IDisposable
         
        public void Dispose()
        { 
             _protocol.Dispose(); 
        }

        #endregion Implementation of IDisposable

        #region Implementation of IMessageSender

        public EndPoint RemoteAddress => new IPEndPoint(_transport.Host, _transport.Port);

        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAsync(TransportMessage message)
        {
            await _protocol.WriteMessageBeginAsync(new TMessage("thrift", TMessageType.Call, 0));
            var binary = GetBinary(message);
            await _protocol.WriteMessageEndAsync();
            await _protocol.WriteBinaryAsync(binary);
        }

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAndFlushAsync(TransportMessage message)
        {
            await _protocol.WriteMessageBeginAsync(new TMessage("thrift", TMessageType.Call, 0));
            var binary = GetBinary(message);
            await _protocol.WriteBinaryAsync(binary);
            await _protocol.WriteMessageEndAsync();
            await _protocol.Transport.FlushAsync();
        }

        #endregion Implementation of IMessageSender
    }

    public class ThriftServerMessageSender : ThriftMessageSender, IMessageSender
    {
        private readonly TProtocol _protocol;
        private readonly TSocketTransport _transport;

        public ThriftServerMessageSender(ITransportMessageEncoder transportMessageEncoder, TProtocol context) : base(transportMessageEncoder)
        {
            _protocol = context;
            _transport = (TSocketTransport) _protocol.Transport;
        }

        public EndPoint RemoteAddress => new IPEndPoint(_transport.Host, _transport.Port);

        public async Task SendAsync(TransportMessage message)
        {
            await _protocol.WriteMessageBeginAsync(new TMessage("thrift", TMessageType.Call, 0));
            var buffer = GetBinary(message);
            await _protocol.WriteBinaryAsync(buffer);
            await _protocol.WriteMessageEndAsync();
        } 

        public async Task SendAndFlushAsync(TransportMessage message)
        {
            await _protocol.WriteMessageBeginAsync(new TMessage("thrift", TMessageType.Call,0));
            var binary = GetBinary(message);
            await _protocol.WriteBinaryAsync(binary);
            await _protocol.WriteMessageEndAsync();
            await _protocol.Transport.FlushAsync();
        }
    }
}

