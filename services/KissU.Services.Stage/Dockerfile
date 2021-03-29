#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["services/KissU.Services.Stage/KissU.Services.Stage.csproj", "services/KissU.Services.Stage/"]
COPY ["modules/common/KissU.Modules.Common.Service.Contracts/KissU.Modules.Common.Service.Contracts.csproj", "modules/common/KissU.Modules.Common.Service.Contracts/"]
COPY ["modules/identity/KissU.Modules.Identity.Service.Contracts/KissU.Modules.Identity.Service.Contracts.csproj", "modules/identity/KissU.Modules.Identity.Service.Contracts/"]
COPY ["modules/account/KissU.Modules.Account.Service.Contracts/KissU.Modules.Account.Service.Contracts.csproj", "modules/account/KissU.Modules.Account.Service.Contracts/"]
COPY ["modules/account/KissU.Modules.Account.Application.Contracts/KissU.Modules.Account.Application.Contracts.csproj", "modules/account/KissU.Modules.Account.Application.Contracts/"]
RUN dotnet restore "services/KissU.Services.Stage/KissU.Services.Stage.csproj"
COPY . .
WORKDIR "/src/services/KissU.Services.Stage"
RUN dotnet build "KissU.Services.Stage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KissU.Services.Stage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KissU.Services.Stage.dll"]