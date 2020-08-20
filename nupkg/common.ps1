# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    "framework",
    "modules/account",
    "modules/audit-logging",
    "modules/background-jobs",
    "modules/feature-management",
    "modules/identity",
    "modules/identityserver",
    "modules/permission-management",
    "modules/setting-management",
    "modules/tenant-management",
    "modules/users"
)

# List of projects
$projects = (

    # framework
    "framework/src/KissU",
    "framework/src/KissU.Core",
    "framework/src/KissU.Abp.Autofac",
    "framework/src/KissU.Abp.Business",
    "framework/src/KissU.AspNetCore",
    "framework/src/KissU.WebSocket",
    "framework/src/KissU.CPlatform",
    "framework/src/KissU.ApiGateWay",
    "framework/src/KissU.Caching",
    "framework/src/KissU.Codec.MessagePack",
    "framework/src/KissU.Codec.ProtoBuffer",
    "framework/src/KissU.ServiceDiscovery.Consul",
    "framework/src/KissU.DotNetty.DNS",
    "framework/src/KissU.DotNetty",
    "framework/src/KissU.DotNetty.WebSocket",
    "framework/src/KissU.EventBus.Kafka",
    "framework/src/KissU.EventBus.RabbitMQ",
    "framework/src/KissU.Thrift",
    "framework/src/KissU.Grpc",
    "framework/src/KissU.Kestrel.Http",
    "framework/src/KissU.Logging.Log4net",
    "framework/src/KissU.Logging.NLog",
    "framework/src/KissU.DotNetty.Http",
    "framework/src/KissU.DotNetty.Mqtt",
    "framework/src/KissU.DotNetty.Udp",
    "framework/src/KissU.ServiceProxy",
    "framework/src/KissU.BackgroundServer",
    "framework/src/KissU.Kestrel.Swagger",
    "framework/src/KissU.ServiceDiscovery.Zookeeper",
    "framework/src/KissU.Apm.Skywalking",
    "framework/src/KissU.Logging.Serilog",
    "framework/src/KissU.Configuration.Apollo",
    "framework/src/KissU.Kestrel.Nlog",
    "framework/src/KissU.Kestrel.Log4net",
    "framework/src/KissU.Kestrel.Stage",
    "framework/src/KissU.Kestrel",
    "framework/src/KissU.Kestrel.IdentityServer",

    # modules/account
    "modules/account/src/KissU.Modules.Account.Application.Contracts",
    "modules/account/src/KissU.Modules.Account.Application",
    "modules/account/src/KissU.Modules.Account.Service.Contracts",
    "modules/account/src/KissU.Modules.Account.Service",
        
    # modules/audit-logging
    "modules/audit-logging/src/KissU.Modules.AuditLogging.Domain",
    "modules/audit-logging/src/KissU.Modules.AuditLogging.Domain.Shared",
    "modules/audit-logging/src/KissU.Modules.AuditLogging.EntityFrameworkCore",
    "modules/audit-logging/src/KissU.Modules.AuditLogging.MongoDB",

    # modules/background-jobs
    "modules/background-jobs/src/KissU.Modules.BackgroundJobs.Domain",
    "modules/background-jobs/src/KissU.Modules.BackgroundJobs.Domain.Shared",
    "modules/background-jobs/src/KissU.Modules.BackgroundJobs.EntityFrameworkCore",
    "modules/background-jobs/src/KissU.Modules.BackgroundJobs.MongoDB",

    # modules/feature-management
    "modules/feature-management/src/KissU.Modules.FeatureManagement.Application.Contracts",
    "modules/feature-management/src/KissU.Modules.FeatureManagement.Application",
    "modules/feature-management/src/KissU.Modules.FeatureManagement.Domain",
    "modules/feature-management/src/KissU.Modules.FeatureManagement.Domain.Shared",
    "modules/feature-management/src/KissU.Modules.FeatureManagement.EntityFrameworkCore",
    "modules/feature-management/src/KissU.Modules.FeatureManagement.MongoDB",
    "modules/feature-management/src/KissU.Modules.FeatureManagement.Service.Contracts",
    "modules/feature-management/src/KissU.Modules.FeatureManagement.Service",

    # modules/identity
    "modules/identity/src/KissU.Modules.Identity.Application.Contracts",
    "modules/identity/src/KissU.Modules.Identity.Application",
    "modules/identity/src/KissU.Modules.Identity.AspNetCore",
    "modules/identity/src/KissU.Modules.Identity.Domain",
    "modules/identity/src/KissU.Modules.Identity.Domain.Shared",
    "modules/identity/src/KissU.Modules.Identity.EntityFrameworkCore",
    "modules/identity/src/KissU.Modules.Identity.Service.Contracts",
    "modules/identity/src/KissU.Modules.Identity.Service",
    
    # modules/identityserver
    "modules/identityserver/src/KissU.Modules.IdentityServer.Domain",
    "modules/identityserver/src/KissU.Modules.IdentityServer.Domain.Shared",
    "modules/identityserver/src/KissU.Modules.IdentityServer.EntityFrameworkCore",
    "modules/identityserver/src/KissU.Modules.IdentityServer.MongoDB",

    # modules/permission-management
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Application.Contracts",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Application",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Domain",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Domain.Shared",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Domain.Identity",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Domain.IdentityServer",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.EntityFrameworkCore",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Service.Contracts",
    "modules/permission-management/src/KissU.Modules.PermissionManagement.Service",

    # modules/setting-management
    "modules/setting-management/src/KissU.Modules.SettingManagement.Domain",
    "modules/setting-management/src/KissU.Modules.SettingManagement.Domain.Shared",
    "modules/setting-management/src/KissU.Modules.SettingManagement.EntityFrameworkCore",
    "modules/setting-management/src/KissU.Modules.SettingManagement.MongoDB",

    # modules/tenant-management
    "modules/tenant-management/src/KissU.Modules.TenantManagement.Application.Contracts",
    "modules/tenant-management/src/KissU.Modules.TenantManagement.Application",
    "modules/tenant-management/src/KissU.Modules.TenantManagement.Domain",
    "modules/tenant-management/src/KissU.Modules.TenantManagement.Domain.Shared",
    "modules/tenant-management/src/KissU.Modules.TenantManagement.EntityFrameworkCore",
    "modules/tenant-management/src/KissU.Modules.TenantManagement.MongoDB",
    "modules/tenant-management/src/KissU.Modules.TenantManagement.Service.Contracts",
    "modules/tenant-management/src/KissU.Modules.TenantManagement.Service",

    # modules/users
    "modules/users/src/KissU.Modules.Users.Abstractions",
    "modules/users/src/KissU.Modules.Users.Domain",
    "modules/users/src/KissU.Modules.Users.Domain.Shared",
    "modules/users/src/KissU.Modules.Users.MongoDB",
    "modules/users/src/KissU.Modules.Users.EntityFrameworkCore"
)
