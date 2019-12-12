using System;

namespace KissU.Core.DotNettyWSServer.Runtime
{
    public class WSServiceEntry
    {
        public string Path { get; set; }

        public Type Type { get; set; }

        public WSBehavior Behavior { get; set; }
    }
}
