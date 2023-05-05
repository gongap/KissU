#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 50000/tcp
EXPOSE 51000/tcp 51100/tcp 
EXPOSE 52000/tcp
EXPOSE 53000/tcp
EXPOSE 54000/tcp
EXPOSE 55000/udp
ENV  Server_Ip *
ENV  Server_Name KissU.MseServer
ENV  Mapping_Ip  ''
ENV  Wan_Ip  ''
ENV  Protocols  'Rpc'
ENV  DockerDeployMode Standard
ENV  UseEngineParts DotNettyModule;MessagePackModule;ConsulModule;ServiceProxyModule;SerilogModule;ApiGateWayModule;SkywalkingModule;
ENV  UseAspNetCore ''
ENV  EnableHttps false
ENV  AddIdentityServerAuthentication false
ENV  Authority http://*:9080
ENV  RootPath /app/services
ENV  Register_Conn 127.0.0.1:8500
ENV  AccessPolicyOrigins http://*
ENV  UserInfoEndpoint http://*:51000/connect/userinfo
WORKDIR /app
COPY ./ /app
ENTRYPOINT ["dotnet", "KissU.MseServer.dll"]
