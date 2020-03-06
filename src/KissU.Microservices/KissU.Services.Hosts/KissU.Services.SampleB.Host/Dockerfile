#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/KissU.Microservices/KissU.Services.Hosts/KissU.Services.SampleB.Host/KissU.Services.SampleB.Host.csproj", "src/KissU.Microservices/KissU.Services.Hosts/KissU.Services.SampleB.Host/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNetty/KissU.Core.DotNetty.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNetty/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.CPlatform/KissU.Core.CPlatform.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.CPlatform/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting/KissU.Core.ServiceHosting.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.KestrelHttpServer/KissU.Core.KestrelHttpServer.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.KestrelHttpServer/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ProxyGenerator/KissU.Core.ProxyGenerator.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ProxyGenerator/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Configuration.Apollo/KissU.Core.Configuration.Apollo.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Configuration.Apollo/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Log4net/KissU.Core.Kestrel.Log4net.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Log4net/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Log4net/KissU.Core.Log4net.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Log4net/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Common/KissU.Core.Common.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Common/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.NLog/KissU.Core.Nlog.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.NLog/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Zookeeper/KissU.Core.Zookeeper.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Zookeeper/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.WS/KissU.Core.Protocol.WS.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.WS/"]
COPY ["src/KissU.BuildingBlocks/WebSocket/WebSocketCore/WebSocketCore.csproj", "src/KissU.BuildingBlocks/WebSocket/WebSocketCore/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNettyWSServer/KissU.Core.DotNettyWSServer.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNettyWSServer/"]
COPY ["src/KissU.BuildingBlocks/KissU.Apm/KissU.Apm.Skywalking/KissU.Apm.Skywalking.csproj", "src/KissU.BuildingBlocks/KissU.Apm/KissU.Apm.Skywalking/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Udp/KissU.Core.Protocol.Udp.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Udp/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Consul/KissU.Core.Consul.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Consul/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.DNS/KissU.Core.DNS.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.DNS/"]
COPY ["src/KissU.BuildingBlocks/DotNetty.Codecs/DotNetty.Codecs.DNS/DotNetty.Codecs.DNS.csproj", "src/KissU.BuildingBlocks/DotNetty.Codecs/DotNetty.Codecs.DNS/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.ProtoBuffer/KissU.Core.Codec.ProtoBuffer.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.ProtoBuffer/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Mqtt/KissU.Core.Protocol.Mqtt.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Mqtt/"]
COPY ["src/KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service/KissU.Modules.SampleB.Service.csproj", "src/KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service/"]
COPY ["src/KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service.Contracts/KissU.Modules.SampleB.Service.Contracts.csproj", "src/KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service.Contracts/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.System/KissU.Core.System.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.System/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Caching/KissU.Core.Caching.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Caching/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting.Extensions/KissU.Core.ServiceHosting.Extensions.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting.Extensions/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Grpc/KissU.Core.Grpc.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Grpc/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ApiGateWay/KissU.Core.ApiGateWay.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.ApiGateWay/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Http/KissU.Core.Protocol.Http.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Http/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util/KissU.Util.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Nlog/KissU.Core.Kestrel.Nlog.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Nlog/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusRabbitMQ/KissU.Core.EventBusRabbitMQ.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusRabbitMQ/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Swagger/KissU.Core.Swagger.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Swagger/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.MessagePack/KissU.Core.Codec.MessagePack.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.MessagePack/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Serilog/KissU.Core.Serilog.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.Serilog/"]
COPY ["src/KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusKafka/KissU.Core.EventBusKafka.csproj", "src/KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusKafka/"]
RUN dotnet restore "src/KissU.Microservices/KissU.Services.Hosts/KissU.Services.SampleB.Host/KissU.Services.SampleB.Host.csproj"
COPY . .
WORKDIR "/src/src/KissU.Microservices/KissU.Services.Hosts/KissU.Services.SampleB.Host"
RUN dotnet build "KissU.Services.SampleB.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KissU.Services.SampleB.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KissU.Services.SampleB.Host.dll"]