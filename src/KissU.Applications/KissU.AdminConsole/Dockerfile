#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/KissU.Applications/KissU.AdminConsole/KissU.AdminConsole.csproj", "src/KissU.Applications/KissU.AdminConsole/"]
RUN dotnet restore "src/KissU.Applications/KissU.AdminConsole/KissU.AdminConsole.csproj"
COPY . .
WORKDIR "/src/src/KissU.Applications/KissU.AdminConsole"
RUN dotnet build "KissU.AdminConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KissU.AdminConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KissU.AdminConsole.dll"]