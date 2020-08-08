# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    "framework"
    # "modules/account",
    # "modules/audit-logging",
    # "modules/background-jobs",
    # "modules/blogging",
    # "modules/client-simulation",
    # "modules/docs",
    # "modules/feature-management",
    # "modules/identity",
    # "modules/identityserver",
    # "modules/permission-management",
    # "modules/setting-management",
    # "modules/tenant-management",
    # "modules/users",
    # "modules/virtual-file-explorer",
	# "modules/blob-storing-database"
)

# List of projects
$projects = (

    # framework
    "framework/src/KissU",
    "framework/src/KissU.Core",
    "framework/src/KissU.Abp",
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
    "framework/src/KissU.Kestrel.IdentityServer"

    # # modules/account
    # "modules/account/src/Volo.Abp.Account.Application.Contracts",
    # "modules/account/src/Volo.Abp.Account.Application",
    # "modules/account/src/Volo.Abp.Account.HttpApi.Client",
    # "modules/account/src/Volo.Abp.Account.HttpApi",
    # "modules/account/src/Volo.Abp.Account.Web",
    # "modules/account/src/Volo.Abp.Account.Web.IdentityServer",
        
    # # modules/audit-logging
    # "modules/audit-logging/src/Volo.Abp.AuditLogging.Domain",
    # "modules/audit-logging/src/Volo.Abp.AuditLogging.Domain.Shared",
    # "modules/audit-logging/src/Volo.Abp.AuditLogging.EntityFrameworkCore",
    # "modules/audit-logging/src/Volo.Abp.AuditLogging.MongoDB",

    # # modules/background-jobs
    # "modules/background-jobs/src/Volo.Abp.BackgroundJobs.Domain",
    # "modules/background-jobs/src/Volo.Abp.BackgroundJobs.Domain.Shared",
    # "modules/background-jobs/src/Volo.Abp.BackgroundJobs.EntityFrameworkCore",
    # "modules/background-jobs/src/Volo.Abp.BackgroundJobs.MongoDB",

    # # modules/blogging
    # "modules/blogging/src/Volo.Blogging.Application.Contracts.Shared",
    # "modules/blogging/src/Volo.Blogging.Application.Contracts",
    # "modules/blogging/src/Volo.Blogging.Application",
    # "modules/blogging/src/Volo.Blogging.Domain",
    # "modules/blogging/src/Volo.Blogging.Domain.Shared",
    # "modules/blogging/src/Volo.Blogging.EntityFrameworkCore",
    # "modules/blogging/src/Volo.Blogging.HttpApi.Client",
    # "modules/blogging/src/Volo.Blogging.HttpApi",
    # "modules/blogging/src/Volo.Blogging.MongoDB",
    # "modules/blogging/src/Volo.Blogging.Web",
    # "modules/blogging/src/Volo.Blogging.Admin.Application",
    # "modules/blogging/src/Volo.Blogging.Admin.Application.Contracts",
    # "modules/blogging/src/Volo.Blogging.Admin.HttpApi",
    # "modules/blogging/src/Volo.Blogging.Admin.HttpApi.Client",
    # "modules/blogging/src/Volo.Blogging.Admin.Web",

    # # modules/client-simulation
    # "modules/client-simulation/src/Volo.ClientSimulation",
    # "modules/client-simulation/src/Volo.ClientSimulation.Web",

    # # modules/docs
    # "modules/docs/src/Volo.Docs.Admin.Application.Contracts",
    # "modules/docs/src/Volo.Docs.Admin.Application",
    # "modules/docs/src/Volo.Docs.Admin.HttpApi.Client",
    # "modules/docs/src/Volo.Docs.Admin.HttpApi",
    # "modules/docs/src/Volo.Docs.Admin.Web",
    # "modules/docs/src/Volo.Docs.Application.Contracts",
    # "modules/docs/src/Volo.Docs.Application",
    # "modules/docs/src/Volo.Docs.Domain",
    # "modules/docs/src/Volo.Docs.Domain.Shared",
    # "modules/docs/src/Volo.Docs.EntityFrameworkCore",
    # "modules/docs/src/Volo.Docs.HttpApi.Client",
    # "modules/docs/src/Volo.Docs.HttpApi",
    # "modules/docs/src/Volo.Docs.MongoDB",
    # "modules/docs/src/Volo.Docs.Web",

    # # modules/feature-management
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.Application.Contracts",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.Application",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.Domain",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.Domain.Shared",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.EntityFrameworkCore",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.HttpApi.Client",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.HttpApi",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.MongoDB",
    # "modules/feature-management/src/Volo.Abp.FeatureManagement.Web",

    # # modules/identity
    # "modules/identity/src/Volo.Abp.Identity.Application.Contracts",
    # "modules/identity/src/Volo.Abp.Identity.Application",
    # "modules/identity/src/Volo.Abp.Identity.AspNetCore",
    # "modules/identity/src/Volo.Abp.Identity.Domain",
    # "modules/identity/src/Volo.Abp.Identity.Domain.Shared",
    # "modules/identity/src/Volo.Abp.Identity.EntityFrameworkCore",
    # "modules/identity/src/Volo.Abp.Identity.HttpApi.Client",
    # "modules/identity/src/Volo.Abp.Identity.HttpApi",
    # "modules/identity/src/Volo.Abp.Identity.MongoDB",
    # "modules/identity/src/Volo.Abp.Identity.Web",
    # "modules/identity/src/Volo.Abp.PermissionManagement.Domain.Identity",
    
    # # modules/identityserver
    # "modules/identityserver/src/Volo.Abp.IdentityServer.Domain",
    # "modules/identityserver/src/Volo.Abp.IdentityServer.Domain.Shared",
    # "modules/identityserver/src/Volo.Abp.IdentityServer.EntityFrameworkCore",
    # "modules/identityserver/src/Volo.Abp.IdentityServer.MongoDB",
    # "modules/identityserver/src/Volo.Abp.PermissionManagement.Domain.IdentityServer",

    # # modules/permission-management
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.Application.Contracts",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.Application",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.Domain",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.Domain.Shared",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.EntityFrameworkCore",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.HttpApi.Client",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.HttpApi",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.MongoDB",
    # "modules/permission-management/src/Volo.Abp.PermissionManagement.Web",

    # # modules/setting-management
    # "modules/setting-management/src/Volo.Abp.SettingManagement.Domain",
    # "modules/setting-management/src/Volo.Abp.SettingManagement.Domain.Shared",
    # "modules/setting-management/src/Volo.Abp.SettingManagement.EntityFrameworkCore",
    # "modules/setting-management/src/Volo.Abp.SettingManagement.MongoDB",
    # "modules/setting-management/src/Volo.Abp.SettingManagement.Web",

    # # modules/tenant-management
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.Application.Contracts",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.Application",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.Domain",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.Domain.Shared",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.EntityFrameworkCore",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.HttpApi.Client",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.HttpApi",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.MongoDB",
    # "modules/tenant-management/src/Volo.Abp.TenantManagement.Web",

    # # modules/users
    # "modules/users/src/Volo.Abp.Users.Abstractions",
    # "modules/users/src/Volo.Abp.Users.Domain",
    # "modules/users/src/Volo.Abp.Users.Domain.Shared",
    # "modules/users/src/Volo.Abp.Users.EntityFrameworkCore",
    # "modules/users/src/Volo.Abp.Users.MongoDB",

    # # modules/virtual-file-explorer
    # "modules/virtual-file-explorer/src/Volo.Abp.VirtualFileExplorer.Web",
	
    # # modules/blob-storing-database
    # "modules/blob-storing-database/src/Volo.Abp.BlobStoring.Database.Domain",
    # "modules/blob-storing-database/src/Volo.Abp.BlobStoring.Database.Domain.Shared",
    # "modules/blob-storing-database/src/Volo.Abp.BlobStoring.Database.EntityFrameworkCore",
    # "modules/blob-storing-database/src/Volo.Abp.BlobStoring.Database.MongoDB"
)
