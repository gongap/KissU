端口分配规则：

KissU.MicroService
    微服务默认主机：50000，
    微服务主机Host：50000，50001，50002，...
          "HttpPort": "${HttpPort}|51000",
          "WSPort": "${WSPort}|52000",
          "MQTTPort": "${MQTTPort}|53000",
          "GrpcPort": "${GrpcPort}|54000",
          "UdpPort": "${UdpPort}|55000",
          "RtmpPort": "${RtmpPort}|56000",
          "HttpFlvPort": "${HttpFlvPort}|57000"
    微服务网关Stage：
         "HttpPorts": "${StageHttpPorts}|51100,51200",
    说明：5开头的为微服务端口，
          500XX，最后两位XX为不同服务主机端口（最多99个），
          5X000，第二位X为同一微服务主机的不同协议端口，规则参考上面（最多9个），
          51X00,   第三位额X为同一微服务主机同一协议的多个配置端口（最多9个），
    举例：52508，5代表此端口提供微服务，25代表此端口提供WebSocket服务，08代表这是KissU.Msm.Im服务

    微服务模块端口：
    1  KissU.Msm.Identity                                        端口：50001
    2  KissU.Msm.IdentityServer                             		端口：50002
    3  KissU.Msm.AppCenter                                       端口：50003
    4  KissU.Msm.Sms                                             端口：50004
    5  KissU.Msm.Blob                                            端口：50005
    6  KissU.Msm.Cms                                             端口：50006
    7  KissU.Msm.Lbs                                             端口：50007
    8  KissU.Msm.Im                                              端口：50008
    8  KissU.Msm.PermissionManagement                			端口：50009
    9  KissU.Partner                                             端口：50020
    10 KissU.Dispatcher                                          端口：50021

KissU.AuthServer
     认证中心：9080，9443
KissU.AdminConsole
     管理中心：8080，8443