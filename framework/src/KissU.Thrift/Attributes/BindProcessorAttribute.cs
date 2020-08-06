using System;

namespace KissU.Thrift.Attributes
{
    public class BindProcessorAttribute: Attribute
    {
        public BindProcessorAttribute(Type processorType) 
        {
            ProcessorType = processorType;
        }

        public Type ProcessorType { get; set; }
    }
}
