@echo off
rem 本脚本用于生成自签名服务端证书，执行前需要先安装好 OpenSSL。
chcp 65001
setlocal
set filename=server
set password=SpectrumMonitoring@20191228
rem 生成自签名服务端证书和私钥

echo 请以回车确认证书信息并继续。
openssl req -x509 -nodes -days 3650 -newkey rsa:2048 -utf8 -out %filename%.crt -keyout %filename%.key -config %filename%.conf
rem 生成服务端个人信息交换证书
openssl pkcs12 -export -in %filename%.crt -inkey %filename%.key -out %filename%.pfx -password pass:%password%
del /q %filename%.key %filename%.crt
move /y %filename%.pfx ..\src\
echo 请用鼠标双击证书文件“..\src\%filename%.pfx”，以导入证书，
echo 导入到“受信任的根证书颁发机构”中，密码为“%password%”，
echo 以便系统信任该证书。
pause
chcp 936
