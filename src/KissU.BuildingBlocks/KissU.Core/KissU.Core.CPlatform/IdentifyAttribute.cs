using System;

namespace KissU.Core.CPlatform
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class IdentifyAttribute : Attribute
    {
        public IdentifyAttribute(CommunicationProtocol name)
        {
            this.Name = name;
        }

        public CommunicationProtocol Name { get; set; }
    }
}

