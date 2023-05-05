using KissU.CPlatform;
using KissU.CPlatform.Support;

namespace KissU.Workbench.Models
{
    public class Descriptor
    {
        public ServiceDescriptor ServiceDescriptor { get; set; }
        public ServiceCommandDescriptor CommandDescriptor { get; set; }
        public string StrategyType  => CommandDescriptor.Strategy.ToString();
    }
}
