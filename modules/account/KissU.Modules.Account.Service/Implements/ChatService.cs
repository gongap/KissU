using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts;
using KissU.ServiceProxy;
using KissU.WebSocket;
using KissU.WebSocket.Core;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Modules.Account.Service.Implements
{
    public class ChatService : WSBehavior, IChatService
    {
        private static readonly ConcurrentDictionary<string, string> _users = new ConcurrentDictionary<string, string>();
        private static readonly ConcurrentDictionary<string, string> _clients = new ConcurrentDictionary<string, string>();
        private string _name;
        private string _to;


        protected override void OnMessage(MessageEventArgs e)
        {
            if (_clients.ContainsKey(ID))
            {
                Dictionary<string, object> model = new Dictionary<string, object>();
                model.Add("name", _to);
                model.Add("data", e.Data);
                var result = ServiceLocator.GetService<IServiceProxyProvider>()
                     .Invoke<object>(model, "api/chat/SendMessage").Result;

            }
        }

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
        public Task SendMessage(string name, string data)
        {
            if (_users.ContainsKey(name))
            {
                GetClient().SendTo($"hello,{name},{data}", _users[name]);
            }
            return Task.CompletedTask;
        }
    }
}
