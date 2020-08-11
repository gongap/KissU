using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace KissU.Modules.Blogging.Application
{
    public static class CommonOperations
    {
        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement { Name = nameof(Update) };
        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = nameof(Delete) };
    }
}
