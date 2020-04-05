#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# You need to build it with the following CLI command:
# docker build -f "./Dockerfile" --force-rm -t kissu/services.stage:linux-latest  "../../"

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 91
EXPOSE 9001
EXPOSE 9101
EXPOSE 9201
EXPOSE 9301

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container 

COPY "KissU.sln" "KissU.sln"

COPY "KissU.BuildingBlocks/DotNetty.Codecs/DotNetty.Codecs.DNS/DotNetty.Codecs.DNS.csproj" "KissU.BuildingBlocks/DotNetty.Codecs/DotNetty.Codecs.DNS/DotNetty.Codecs.DNS.csproj"
COPY "KissU.BuildingBlocks/KissU.Apm/KissU.Apm.Skywalking/KissU.Apm.Skywalking.csproj" "KissU.BuildingBlocks/KissU.Apm/KissU.Apm.Skywalking/KissU.Apm.Skywalking.csproj"
COPY "KissU.BuildingBlocks/KissU.Core/KissU.Core/KissU.Core.csproj" "KissU.BuildingBlocks/KissU.Core/KissU.Core/KissU.Core.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.ApiGateWay/KissU.Surging.ApiGateWay.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.ApiGateWay/KissU.Surging.ApiGateWay.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.AutoMapper/KissU.Surging.AutoMapper.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.AutoMapper/KissU.Surging.AutoMapper.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.BackgroundServer/KissU.Surging.BackgroundServer.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.BackgroundServer/KissU.Surging.BackgroundServer.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Caching/KissU.Surging.Caching.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Caching/KissU.Surging.Caching.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Codec.MessagePack/KissU.Surging.Codec.MessagePack.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Codec.MessagePack/KissU.Surging.Codec.MessagePack.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Codec.ProtoBuffer/KissU.Surging.Codec.ProtoBuffer.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Codec.ProtoBuffer/KissU.Surging.Codec.ProtoBuffer.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Configuration.Apollo/KissU.Surging.Configuration.Apollo.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Configuration.Apollo/KissU.Surging.Configuration.Apollo.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Consul/KissU.Surging.Consul.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Consul/KissU.Surging.Consul.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.CPlatform/KissU.Surging.CPlatform.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.CPlatform/KissU.Surging.CPlatform.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.DNS/KissU.Surging.DNS.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.DNS/KissU.Surging.DNS.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.DotNetty/KissU.Surging.DotNetty.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.DotNetty/KissU.Surging.DotNetty.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.DotNettyWSServer/KissU.Surging.DotNettyWSServer.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.DotNettyWSServer/KissU.Surging.DotNettyWSServer.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.EventBusKafka/KissU.Surging.EventBusKafka.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.EventBusKafka/KissU.Surging.EventBusKafka.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.EventBusRabbitMQ/KissU.Surging.EventBusRabbitMQ.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.EventBusRabbitMQ/KissU.Surging.EventBusRabbitMQ.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Grpc/KissU.Surging.Grpc.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Grpc/KissU.Surging.Grpc.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Kestrel.Log4net/KissU.Surging.Kestrel.Log4net.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Kestrel.Log4net/KissU.Surging.Kestrel.Log4net.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Kestrel.Nlog/KissU.Surging.Kestrel.Nlog.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Kestrel.Nlog/KissU.Surging.Kestrel.Nlog.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.KestrelHttpServer/KissU.Surging.KestrelHttpServer.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.KestrelHttpServer/KissU.Surging.KestrelHttpServer.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Log4net/KissU.Surging.Log4net.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Log4net/KissU.Surging.Log4net.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.NLog/KissU.Surging.Nlog.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.NLog/KissU.Surging.Nlog.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.Http/KissU.Surging.Protocol.Http.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.Http/KissU.Surging.Protocol.Http.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.Mqtt/KissU.Surging.Protocol.Mqtt.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.Mqtt/KissU.Surging.Protocol.Mqtt.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.Udp/KissU.Surging.Protocol.Udp.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.Udp/KissU.Surging.Protocol.Udp.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.WS/KissU.Surging.Protocol.WS.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Protocol.WS/KissU.Surging.Protocol.WS.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.ProxyGenerator/KissU.Surging.ProxyGenerator.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.ProxyGenerator/KissU.Surging.ProxyGenerator.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Serilog/KissU.Surging.Serilog.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Serilog/KissU.Surging.Serilog.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.ServiceHosting/KissU.Surging.ServiceHosting.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.ServiceHosting/KissU.Surging.ServiceHosting.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Stage/KissU.Surging.Stage.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Stage/KissU.Surging.Stage.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Swagger/KissU.Surging.Swagger.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Swagger/KissU.Surging.Swagger.csproj"
COPY "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Zookeeper/KissU.Surging.Zookeeper.csproj" "KissU.BuildingBlocks/KissU.Surging/KissU.Surging.Zookeeper/KissU.Surging.Zookeeper.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Applications/KissU.Util.Applications.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Applications/KissU.Util.Applications.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore.Mvc/KissU.Util.AspNetCore.Mvc.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore.Mvc/KissU.Util.AspNetCore.Mvc.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore/KissU.Util.AspNetCore.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore/KissU.Util.AspNetCore.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz.Payments/KissU.Util.Biz.Payments.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz.Payments/KissU.Util.Biz.Payments.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz/KissU.Util.Biz.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Biz/KissU.Util.Biz.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Caches/KissU.Util.Caches.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Caches/KissU.Util.Caches.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Dapper/KissU.Util.Dapper.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Dapper/KissU.Util.Dapper.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas/KissU.Util.Datas.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas/KissU.Util.Datas.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.MySql/KissU.Util.EntityFrameworkCore.MySql.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.MySql/KissU.Util.EntityFrameworkCore.MySql.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.Oracle/KissU.Util.EntityFrameworkCore.Oracle.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.Oracle/KissU.Util.EntityFrameworkCore.Oracle.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.PgSql/KissU.Util.EntityFrameworkCore.PgSql.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.PgSql/KissU.Util.EntityFrameworkCore.PgSql.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.SqlServer/KissU.Util.EntityFrameworkCore.SqlServer.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore.SqlServer/KissU.Util.EntityFrameworkCore.SqlServer.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore/KissU.Util.EntityFrameworkCore.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.EntityFrameworkCore/KissU.Util.EntityFrameworkCore.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Events/KissU.Util.Events.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Events/KissU.Util.Events.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Logs/KissU.Util.Logs.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Logs/KissU.Util.Logs.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Schedulers/KissU.Util.Schedulers.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Schedulers/KissU.Util.Schedulers.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Search/KissU.Util.Search.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Search/KissU.Util.Search.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Security/KissU.Util.Security.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Security/KissU.Util.Security.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Threading/KissU.Util.Threading.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Threading/KissU.Util.Threading.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Offices/KissU.Util.Tools.Offices.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Offices/KissU.Util.Tools.Offices.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.QrCode/KissU.Util.Tools.QrCode.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.QrCode/KissU.Util.Tools.QrCode.csproj"
COPY "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Sms/KissU.Util.Tools.Sms.csproj" "KissU.BuildingBlocks/KissU.Util/KissU.Util.Tools.Sms/KissU.Util.Tools.Sms.csproj"
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
COPY "KissU.Services/KissU.Services.Host/KissU.Services.Host.csproj" "KissU.Services/KissU.Services.Host/KissU.Services.Host.csproj"
COPY "KissU.Services/KissU.Services.Identity/KissU.Services.Identity.csproj" "KissU.Services/KissU.Services.Identity/KissU.Services.Identity.csproj"
COPY "KissU.Services/KissU.Services.Sample/KissU.Services.SampleA.Host/KissU.Services.SampleA.Host.csproj" "KissU.Services/KissU.Services.Sample/KissU.Services.SampleA.Host/KissU.Services.SampleA.Host.csproj"
COPY "KissU.Services/KissU.Services.Sample/KissU.Services.SampleB.Host/KissU.Services.SampleB.Host.csproj" "KissU.Services/KissU.Services.Sample/KissU.Services.SampleB.Host/KissU.Services.SampleB.Host.csproj"
COPY "KissU.Services/KissU.Services.Stage/KissU.Services.Stage.csproj" "KissU.Services/KissU.Services.Stage/KissU.Services.Stage.csproj"
COPY "tests/KissU.Surging.ServiceHosting.Tests/KissU.Surging.ServiceHosting.Tests.csproj" "tests/KissU.Surging.ServiceHosting.Tests/KissU.Surging.ServiceHosting.Tests.csproj"
COPY "tests/KissU.Util.Biz.Tests.Integration/KissU.Util.Biz.Tests.Integration.csproj" "tests/KissU.Util.Biz.Tests.Integration/KissU.Util.Biz.Tests.Integration.csproj"
COPY "tests/KissU.Util.Datas.Tests.Integration/KissU.Util.Datas.Tests.Integration.csproj" "tests/KissU.Util.Datas.Tests.Integration/KissU.Util.Datas.Tests.Integration.csproj"
COPY "tests/KissU.Util.Tests/KissU.Util.Tests.csproj" "tests/KissU.Util.Tests/KissU.Util.Tests.csproj"
COPY "tests/KissU.Util.Tools.Offices.Tests.Integration/KissU.Util.Tools.Offices.Tests.Integration.csproj" "tests/KissU.Util.Tools.Offices.Tests.Integration/KissU.Util.Tools.Offices.Tests.Integration.csproj"

COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "KissU.sln"

COPY . .
WORKDIR "/src/KissU.Services/KissU.Services.Stage"
RUN dotnet build "KissU.Services.Stage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KissU.Services.Stage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KissU.Services.Stage.dll"]