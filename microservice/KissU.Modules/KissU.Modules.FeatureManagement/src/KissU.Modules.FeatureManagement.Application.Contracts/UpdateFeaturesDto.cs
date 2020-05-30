using System.Collections.Generic;

namespace KissU.Modules.FeatureManagement.Application.Contracts
{
    public class UpdateFeaturesDto
    {
        public List<UpdateFeatureDto> Features { get; set; }
    }
}