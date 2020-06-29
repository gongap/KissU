using System;

namespace KissU.Modules.Application.MultiTenancy
{
    [Serializable]
    public class FindTenantResultDto
    {
        public bool Success { get; set; }

        public Guid? TenantId { get; set; }

        public string Name { get; set; }
    }
}