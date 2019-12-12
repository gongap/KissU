using System;

namespace KissU.Core.DotNettyWSServer.Attributes
{
    public class BehaviorContractAttribute: Attribute
    {

        public string Protocol { get; set; }
    }
}
