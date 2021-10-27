# Paths
$packFolder = (Get-Item -Path "./packages" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../../"

# List of solutions
$solutions = (
    "framework"
)

# List of projects
$projects = (

    # framework
    "framework/src/KissU.AspNetCore",
    "framework/src/KissU.AspNetCore.Swagger",
    "framework/src/KissU.AspNetCore.Stage",
    "framework/src/KissU.AspNetCore.Kestrel",
    "framework/src/KissU.Codec.MessagePack",
    "framework/src/KissU.Codec.ProtoBuffer",
    "framework/src/KissU.EventBus.Kafka",
    "framework/src/KissU.EventBus.RabbitMQ",
    "framework/src/KissU.Logging.Log4net",
    "framework/src/KissU.Logging.NLog",
    "framework/src/KissU.Logging.Serilog",
    "framework/src/KissU.ServiceDiscovery.Consul",
    "framework/src/KissU.ServiceDiscovery.Zookeeper",
    "framework/src/KissU.DotNetty",
    "framework/src/KissU.DotNetty.DNS",
    "framework/src/KissU.DotNetty.Http",
    "framework/src/KissU.DotNetty.Mqtt",
    "framework/src/KissU.DotNetty.Udp",
    "framework/src/KissU.DotNetty.WebSocket",
    "framework/src/KissU.Grpc",
    "framework/src/KissU.Thrift",
    "framework/src/KissU.WebSocket",
    "framework/src/KissU.ApiGateWay",
    "framework/src/KissU.Apm.Skywalking",
    "framework/src/KissU.BackgroundServer",
    "framework/src/KissU.Caching",
    "framework/src/KissU.Configuration.Apollo",
    "framework/src/KissU.Core",
    "framework/src/KissU.Abp",
    "framework/src/KissU.CPlatform",
    "framework/src/KissU.ServiceProxy",
    "framework/src/KissU.Tools.Cli"
)
