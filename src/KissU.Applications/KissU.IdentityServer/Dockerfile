#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY "NuGet.config" "NuGet.config"
COPY ["src/KissU.Applications/KissU.IdentityServer/KissU.IdentityServer.csproj", "src/KissU.Applications/KissU.IdentityServer/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Logs/KissU.Util.Logs.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Logs/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Security/KissU.Util.Security.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Security/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore/KissU.Util.AspNetCore.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util.AspNetCore/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util/KissU.Util.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util/"]
COPY ["src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Application/KissU.Modules.IdentityServer.Application.csproj", "src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Application/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Applications/KissU.Util.Applications.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Applications/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas/KissU.Util.Datas.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas/"]
COPY ["src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Data/KissU.Modules.IdentityServer.Data.csproj", "src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Data/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.SqlServer/KissU.Util.Datas.SqlServer.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.SqlServer/"]
COPY ["src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Domain/KissU.Modules.IdentityServer.Domain.csproj", "src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.Domain/"]
COPY ["src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Application/KissU.Modules.GreatWall.Application.csproj", "src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Application/"]
COPY ["src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Domain/KissU.Modules.GreatWall.Domain.csproj", "src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Domain/"]
COPY ["src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Data/KissU.Modules.GreatWall.Data.csproj", "src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.Data/"]
COPY ["src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.PgSql/KissU.Util.Datas.PgSql.csproj", "src/KissU.BuildingBlocks/KissU.Util/KissU.Util.Datas.PgSql/"]
RUN dotnet restore "src/KissU.Applications/KissU.IdentityServer/KissU.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/KissU.Applications/KissU.IdentityServer"
RUN dotnet build "KissU.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KissU.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KissU.IdentityServer.dll"]