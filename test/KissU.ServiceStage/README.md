�˿ڷ������

KissU.MicroService
    ΢����Ĭ��������50000��
    ΢��������Host��50000��50001��50002��...
          "HttpPort": "${HttpPort}|51000",
          "WSPort": "${WSPort}|52000",
          "MQTTPort": "${MQTTPort}|53000",
          "GrpcPort": "${GrpcPort}|54000",
          "UdpPort": "${UdpPort}|55000",
          "RtmpPort": "${RtmpPort}|56000",
          "HttpFlvPort": "${HttpFlvPort}|57000"
    ΢��������Stage��
         "HttpPorts": "${StageHttpPorts}|51100,51200",
    ˵����5��ͷ��Ϊ΢����˿ڣ�
          500XX�������λXXΪ��ͬ���������˿ڣ����99������
          5X000���ڶ�λXΪͬһ΢���������Ĳ�ͬЭ��˿ڣ�����ο����棨���9������
          51X00,   ����λ��XΪͬһ΢��������ͬһЭ��Ķ�����ö˿ڣ����9������
    ������52508��5�����˶˿��ṩ΢����25�KissU˶˿��ṩWebSocket����08��������KissU.Msm.Im����

    ΢����ģ��˿ڣ�
    1  KissU.Msm.Identity                                        �˿ڣ�50001
    2  KissU.Msm.IdentityServer                             		�˿ڣ�50002
    3  KissU.Msm.AppCenter                                       �˿ڣ�50003
    4  KissU.Msm.Sms                                             �˿ڣ�50004
    5  KissU.Msm.Blob                                            �˿ڣ�50005
    6  KissU.Msm.Cms                                             �˿ڣ�50006
    7  KissU.Msm.Lbs                                             �˿ڣ�50007
    8  KissU.Msm.Im                                              �˿ڣ�50008
    8  KissU.Msm.PermissionManagement                			�˿ڣ�50009
    9  KissU.Partner                                             �˿ڣ�50020
    10 KissU.Dispatcher                                          �˿ڣ�50021

KissU.AuthServer
     ��֤���ģ�9080��9443
KissU.AdminConsole
     �������ģ�8080��8443