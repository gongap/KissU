#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# You need to build it with the following CLI command:
# docker build -f "./Dockerfile" --force-rm -t kissu/services.host:linux-latest  "../../"

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 81
EXPOSE 8001
EXPOSE 8101
EXPOSE 8201
EXPOSE 8301

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds

COPY . .
WORKDIR "/src/KissU.Services/KissU.Services.Host"
RUN dotnet build "KissU.Services.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KissU.Services.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KissU.Services.Host.dll"]