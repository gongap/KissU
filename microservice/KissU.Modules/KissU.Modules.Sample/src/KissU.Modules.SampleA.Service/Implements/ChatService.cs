using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Services.SampleA.Contract;
using KissU.Surging.Protocol.WS;
using KissU.Surging.ProxyGenerator;
using WebSocketCore;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// ChatService.
    /// Implements the <see cref="KissU.Surging.Protocol.WS.WSBehavior" />
    /// Implements the <see cref="IChatService" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Protocol.WS.WSBehavior" />
    /// <seealso cref="IChatService" />
    public class ChatService : WSBehavior, IChatService
    {
        private static readonly ConcurrentDictionary<string, string>
            _users = new ConcurrentDictionary<string, string>();

        private static readonly ConcurrentDictionary<string, string> _clients =
            new ConcurrentDictionary<string, string>();

        private string _name;
        private string _to;

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        /// <returns>Task.</returns>
        public Task SendMessage(string name, string data)
        {
            if (_users.ContainsKey(name))
            {
                GetClient().SendTo($"hello,{name},{data}", _users[name]);
            }

            return Task.CompletedTask;
        }


        /// <summary>
        /// Called when the WebSocket instance for a session receives a message.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:WebSocketCore.MessageEventArgs" /> that represents the event data passed
        /// from a <see cref="E:WebSocketCore.WebSocket.OnMessage" /> event.
        /// </param>
        protected override void OnMessage(MessageEventArgs e)
        {
            if (_clients.ContainsKey(ID))
            {
                var model = new Dictionary<string, object>();
                model.Add("name", _to);
                model.Add("data", e.Data);
                var result = ServiceLocator.GetService<IServiceProxyProvider>()
                    .Invoke<object>(model, "api/chat/SendMessage").Result;
            }
        }

        /// <summary>
        /// Called when the WebSocket connection for a session has been established.
        /// </summary>
        protected override void OnOpen()
        {
            _name = Context.QueryString["name"];
            _to = Context.QueryString["to"];
            if (!string.IsNullOrEmpty(_name))
            {
                _clients[ID] = _name;
                _users[_name] = ID;
            }
        }
    }
}