using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts;
using KissU.Serialization;
using KissU.ServiceProxy;
using KissU.WebSocket;
using KissU.WebSocket.Core;
using Volo.Abp.Users;

namespace KissU.Modules.Account.Service.Implements
{
    /// <summary>
    /// 位置服务
    /// </summary>
    public class LocationService : WSBehavior, ILocationService
    {
        private readonly ISerializer<string> _serializer;

        private static readonly ConcurrentDictionary<string, List<string>> _teamUsers =
            new ConcurrentDictionary<string, List<string>>();

        private static readonly ConcurrentDictionary<string, string> _clients =
            new ConcurrentDictionary<string, string>();

        public LocationService(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (_clients.ContainsKey(ID))
            {
                var model = new Dictionary<string, object>
                    {{"userId", ID}, {"teamId", _clients[ID]}, {"location", e.Data}};
                var result = ServiceLocator.GetService<IServiceProxyProvider>()
                    .Invoke<object>(model, "api/Location/Reprot").Result;
            }
        }

        protected override void OnOpen()
        {
            var teamId = Context.QueryString["teamId"];
            if (!string.IsNullOrEmpty(teamId))
            {
                _clients[ID] = teamId;
                _teamUsers.GetOrAdd(teamId, new List<string>()).Add(ID);
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            if (_clients.ContainsKey(ID))
            {
                var teamId = _clients[ID];
                _clients.TryRemove(ID, out _);
                if (_teamUsers.ContainsKey(teamId))
                {
                    _teamUsers[teamId].Remove(ID);
                }
            }
        }

        public Task Reprot(string userId, string teamId, string location)
        {
            if (_teamUsers.TryGetValue(teamId, out var users))
            {
                foreach (var user in users)
                {
                    if (user != userId)
                    {
                        GetClient().SendTo(location, user);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
