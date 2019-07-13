﻿using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using KissU.IModuleServices.User;

namespace KissU.Modules.Manager.Domain
{
    public class ManagerService : ProxyServiceBase, IManagerService
    {
        public Task<string> SayHello(string name)
        {
              return Task.FromResult($"{name} say:hello");
        }
    }
}
