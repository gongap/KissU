#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds

COPY "KissU.sln" "KissU.sln"

COPY "KissU.BuildingBlocks/DotNetty.Codecs/DotNetty.Codecs.DNS/DotNetty.Codecs.DNS.csproj" "KissU.BuildingBlocks/DotNetty.Codecs/DotNetty.Codecs.DNS/DotNetty.Codecs.DNS.csproj"
COPY "KissU.BuildingBlocks/KissU.Apm/KissU.Apm.Skywalking/KissU.Apm.Skywalking.csproj" "KissU.BuildingBlocks/KissU.Apm/KissU.Apm.Skywalking/KissU.Apm.Skywalking.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.ApiGateWay/KissU.Core.ApiGateWay.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.ApiGateWay/KissU.Core.ApiGateWay.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.AutoMapper/KissU.Core.AutoMapper.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.AutoMapper/KissU.Core.AutoMapper.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Caching/KissU.Core.Caching.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Caching/KissU.Core.Caching.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.MessagePack/KissU.Core.Codec.MessagePack.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.MessagePack/KissU.Core.Codec.MessagePack.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.ProtoBuffer/KissU.Core.Codec.ProtoBuffer.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Codec.ProtoBuffer/KissU.Core.Codec.ProtoBuffer.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Common/KissU.Core.Common.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Common/KissU.Core.Common.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Configuration.Apollo/KissU.Core.Configuration.Apollo.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Configuration.Apollo/KissU.Core.Configuration.Apollo.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Consul/KissU.Core.Consul.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Consul/KissU.Core.Consul.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.CPlatform/KissU.Core.CPlatform.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.CPlatform/KissU.Core.CPlatform.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.DNS/KissU.Core.DNS.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.DNS/KissU.Core.DNS.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNetty/KissU.Core.DotNetty.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNetty/KissU.Core.DotNetty.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNettyWSServer/KissU.Core.DotNettyWSServer.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.DotNettyWSServer/KissU.Core.DotNettyWSServer.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusKafka/KissU.Core.EventBusKafka.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusKafka/KissU.Core.EventBusKafka.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusRabbitMQ/KissU.Core.EventBusRabbitMQ.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.EventBusRabbitMQ/KissU.Core.EventBusRabbitMQ.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Grpc/KissU.Core.Grpc.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Grpc/KissU.Core.Grpc.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Log4net/KissU.Core.Kestrel.Log4net.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Log4net/KissU.Core.Kestrel.Log4net.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Nlog/KissU.Core.Kestrel.Nlog.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Kestrel.Nlog/KissU.Core.Kestrel.Nlog.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.KestrelHttpServer/KissU.Core.KestrelHttpServer.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.KestrelHttpServer/KissU.Core.KestrelHttpServer.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Log4net/KissU.Core.Log4net.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Log4net/KissU.Core.Log4net.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.NLog/KissU.Core.Nlog.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.NLog/KissU.Core.Nlog.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Http/KissU.Core.Protocol.Http.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Http/KissU.Core.Protocol.Http.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Mqtt/KissU.Core.Protocol.Mqtt.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Mqtt/KissU.Core.Protocol.Mqtt.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Udp/KissU.Core.Protocol.Udp.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.Udp/KissU.Core.Protocol.Udp.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.WS/KissU.Core.Protocol.WS.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Protocol.WS/KissU.Core.Protocol.WS.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.ProxyGenerator/KissU.Core.ProxyGenerator.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.ProxyGenerator/KissU.Core.ProxyGenerator.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Serilog/KissU.Core.Serilog.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Serilog/KissU.Core.Serilog.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting.Extensions/KissU.Core.ServiceHosting.Extensions.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting.Extensions/KissU.Core.ServiceHosting.Extensions.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting/KissU.Core.ServiceHosting.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.ServiceHosting/KissU.Core.ServiceHosting.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Stage/KissU.Core.Stage.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Stage/KissU.Core.Stage.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Swagger/KissU.Core.Swagger.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Swagger/KissU.Core.Swagger.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.System/KissU.Core.System.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.System/KissU.Core.System.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core.Zookeeper/KissU.Core.Zookeeper.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core.Zookeeper/KissU.Core.Zookeeper.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Applications/KissU.Util.Applications.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Applications/KissU.Util.Applications.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore.Webs/KissU.Util.AspNetCore.Webs.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore.Webs/KissU.Util.AspNetCore.Webs.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore/KissU.Util.AspNetCore.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore/KissU.Util.AspNetCore.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz.Payments/KissU.Util.Biz.Payments.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz.Payments/KissU.Util.Biz.Payments.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz/KissU.Util.Biz.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz/KissU.Util.Biz.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Caches/KissU.Util.Caches.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Caches/KissU.Util.Caches.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.MySql/KissU.Util.Datas.MySql.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.MySql/KissU.Util.Datas.MySql.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.Oracle/KissU.Util.Datas.Oracle.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.Oracle/KissU.Util.Datas.Oracle.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.PgSql/KissU.Util.Datas.PgSql.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.PgSql/KissU.Util.Datas.PgSql.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.SqlServer/KissU.Util.Datas.SqlServer.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.SqlServer/KissU.Util.Datas.SqlServer.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas/KissU.Util.Datas.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas/KissU.Util.Datas.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Events/KissU.Util.Events.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Events/KissU.Util.Events.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Logs/KissU.Util.Logs.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Logs/KissU.Util.Logs.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Schedulers/KissU.Util.Schedulers.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Schedulers/KissU.Util.Schedulers.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Search/KissU.Util.Search.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Search/KissU.Util.Search.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Security/KissU.Util.Security.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Security/KissU.Util.Security.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Offices/KissU.Util.Tools.Offices.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Offices/KissU.Util.Tools.Offices.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.QrCode/KissU.Util.Tools.QrCode.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.QrCode/KissU.Util.Tools.QrCode.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Sms/KissU.Util.Tools.Sms.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Sms/KissU.Util.Tools.Sms.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util/KissU.Util.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util/KissU.Util.csproj"
COPY "KissU.BuildingBlocks/WebSocket/WebSocketCore/WebSocketCore.csproj" "KissU.BuildingBlocks/WebSocket/WebSocketCore/WebSocketCore.csproj"
COPY "KissU.Clients/KissU.AdminConsole/KissU.AdminConsole.csproj" "KissU.Clients/KissU.AdminConsole/KissU.AdminConsole.csproj"
COPY "KissU.Clients/KissU.Client/KissU.Client.csproj" "KissU.Clients/KissU.Client/KissU.Client.csproj"
COPY "KissU.Modules/KissU.Modules.Admin/KissU.Modules.Admin.Service.Contracts/KissU.Modules.Admin.Service.Contracts.csproj" "KissU.Modules/KissU.Modules.Admin/KissU.Modules.Admin.Service.Contracts/KissU.Modules.Admin.Service.Contracts.csproj"
COPY "KissU.Modules/KissU.Modules.Admin/KissU.Modules.Admin.Service/KissU.Modules.Admin.Service.csproj" "KissU.Modules/KissU.Modules.Admin/KissU.Modules.Admin.Service/KissU.Modules.Admin.Service.csproj"
COPY "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Application/KissU.Modules.GreatWall.Application.csproj" "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Application/KissU.Modules.GreatWall.Application.csproj"
COPY "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Data/KissU.Modules.GreatWall.Data.csproj" "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Data/KissU.Modules.GreatWall.Data.csproj"
COPY "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.DbMigrator/KissU.Modules.GreatWall.DbMigrator.csproj" "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.DbMigrator/KissU.Modules.GreatWall.DbMigrator.csproj"
COPY "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Domain/KissU.Modules.GreatWall.Domain.csproj" "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Domain/KissU.Modules.GreatWall.Domain.csproj"
COPY "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Service.Contracts/KissU.Modules.GreatWall.Service.Contracts.csproj" "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Service.Contracts/KissU.Modules.GreatWall.Service.Contracts.csproj"
COPY "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Service/KissU.Modules.GreatWall.Service.csproj" "KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Service/KissU.Modules.GreatWall.Service.csproj"
COPY "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Application/KissU.Modules.IdentityServer.Application.csproj" "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Application/KissU.Modules.IdentityServer.Application.csproj"
COPY "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Data/KissU.Modules.IdentityServer.Data.csproj" "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Data/KissU.Modules.IdentityServer.Data.csproj"
COPY "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.DbMigrator/KissU.Modules.IdentityServer.DbMigrator.csproj" "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.DbMigrator/KissU.Modules.IdentityServer.DbMigrator.csproj"
COPY "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Domain/KissU.Modules.IdentityServer.Domain.csproj" "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Domain/KissU.Modules.IdentityServer.Domain.csproj"
COPY "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Service.Contracts/KissU.Modules.IdentityServer.Service.Contracts.csproj" "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Service.Contracts/KissU.Modules.IdentityServer.Service.Contracts.csproj"
COPY "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Service/KissU.Modules.IdentityServer.Service.csproj" "KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Service/KissU.Modules.IdentityServer.Service.csproj"
COPY "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleA.Service.Contracts/KissU.Modules.SampleA.Service.Contracts.csproj" "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleA.Service.Contracts/KissU.Modules.SampleA.Service.Contracts.csproj"
COPY "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleA.Service/KissU.Modules.SampleA.Service.csproj" "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleA.Service/KissU.Modules.SampleA.Service.csproj"
COPY "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service.Contracts/KissU.Modules.SampleB.Service.Contracts.csproj" "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service.Contracts/KissU.Modules.SampleB.Service.Contracts.csproj"
COPY "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service/KissU.Modules.SampleB.Service.csproj" "KissU.Modules/KissU.Modules.Sample/KissU.Modules.SampleB.Service/KissU.Modules.SampleB.Service.csproj"
COPY "KissU.Services/KissU.IdentityServer/KissU.IdentityServer.csproj" "KissU.Services/KissU.IdentityServer/KissU.IdentityServer.csproj"
COPY "KissU.Services/KissU.Services.Hosts/KissU.Services.Host/KissU.Services.Host.csproj" "KissU.Services/KissU.Services.Hosts/KissU.Services.Host/KissU.Services.Host.csproj"
COPY "KissU.Services/KissU.Services.Hosts/KissU.Services.SampleA.Host/KissU.Services.SampleA.Host.csproj" "KissU.Services/KissU.Services.Hosts/KissU.Services.SampleA.Host/KissU.Services.SampleA.Host.csproj"
COPY "KissU.Services/KissU.Services.Hosts/KissU.Services.SampleB.Host/KissU.Services.SampleB.Host.csproj" "KissU.Services/KissU.Services.Hosts/KissU.Services.SampleB.Host/KissU.Services.SampleB.Host.csproj"
COPY "KissU.Services/KissU.Services.Stages/KissU.Services.Stage/KissU.Services.Stage.csproj" "KissU.Services/KissU.Services.Stages/KissU.Services.Stage/KissU.Services.Stage.csproj"
COPY "KissU.Tests/KissU.Core.Tests/KissU.Core.ServiceHosting.Tests/KissU.Core.ServiceHosting.Tests.csproj" "KissU.Tests/KissU.Core.Tests/KissU.Core.ServiceHosting.Tests/KissU.Core.ServiceHosting.Tests.csproj"
COPY "KissU.Tests/KissU.Core.Tests/KissU.Core.Services.Client/KissU.Core.Services.Client.csproj" "KissU.Tests/KissU.Core.Tests/KissU.Core.Services.Client/KissU.Core.Services.Client.csproj"
COPY "KissU.Tests/KissU.Util.Tests/KissU.Util.Biz.Tests.Integration/KissU.Util.Biz.Tests.Integration.csproj" "KissU.Tests/KissU.Util.Tests/KissU.Util.Biz.Tests.Integration/KissU.Util.Biz.Tests.Integration.csproj"
COPY "KissU.Tests/KissU.Util.Tests/KissU.Util.Datas.Tests.Integration/KissU.Util.Datas.Tests.Integration.csproj" "KissU.Tests/KissU.Util.Tests/KissU.Util.Datas.Tests.Integration/KissU.Util.Datas.Tests.Integration.csproj"
COPY "KissU.Tests/KissU.Util.Tests/KissU.Util.Tests/KissU.Util.Tests.csproj" "KissU.Tests/KissU.Util.Tests/KissU.Util.Tests/KissU.Util.Tests.csproj"
COPY "KissU.Tests/KissU.Util.Tests/KissU.Util.Tools.Offices.Tests.Integration/KissU.Util.Tools.Offices.Tests.Integration.csproj" "KissU.Tests/KissU.Util.Tests/KissU.Util.Tools.Offices.Tests.Integration/KissU.Util.Tools.Offices.Tests.Integration.csproj"

COPY "docker-compose.dcproj" "docker-compose.dcproj"

COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "KissU.sln"

COPY . .
WORKDIR "/src/KissU.Services/KissU.Services.Stages/KissU.Services.Stage"
RUN dotnet build "KissU.Services.Stage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KissU.Services.Stage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KissU.Services.Stage.dll"]