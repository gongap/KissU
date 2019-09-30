# KissU应用框架介绍 
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://mit-license.org/)

KissU 是一个分布式微服务应用框架,提供高性能RPC远程服务调用，采用Zookeeper、Consul作为服务的注册中心，集成了哈希，随机，轮询，压力最小优先作为负载均衡的算法，RPC集成采用的是netty框架，采用异步传输。

### 微服务定义
微服务应该是可以自由组合拆分，对于每个业务都是独立的，针对于业务模块的 CRUD 可以注册为服务，而每个服务都是高度自治的，从开发，部署都是独立，而每个服务只做单一功能，利用领域驱动设计去更好的拆分成粒度更小的模块

### 微服务边界
微服务是针对业务的松耦合，也是粒度最小的功能业务模块，针对于行业解决方案，集成相应的service host,而针对于业务需要一些中间件来辅助，比如缓存中间件，eventbus中间件（消息中间件），数据储存中间件,而各个服务又可以互相通过rpc进行可靠性通信。

引擎是微服务的容器，而docker 是服务引擎的容器，而利用k8s或rancher可以针对docker集群化管理，可以服务编排弹性扩容，熟知工具，让工具物尽其用。

### 能做什么
1.简化的服务调用，通过服务规则的指定，就可以做到服务之间的远程调用，无需其它方式的侵入

2.服务自动注册与发现，不需要配置服务提供方地址，注册中心基于ServiceId 或者RoutePath查询服务提供者的地址和元数据，并且能够平滑添加或删除服务提供者。

3.软负载均衡及容错机制，通过surging内部负载算法和容错规则的设定，从而达到内部调用的负载和容错

4.分布式缓存中间件：通过哈希一致性算法来实现负载，并且有健康检查能够平滑的把不健康的服务从列表中删除

5.事件总线：通过对于事件总线的适配可以实现发布订阅交互模式

6.容器化持续集成与持续交付 ：通过构建一体化Devops平台,实现项目的自动化构建、部署、测试和发布，从而提高生产环境的可靠性、稳定性、弹性和安全性。

7.业务模块化驱动引擎，通过加载指定业务模块，能够更加灵活、高效的部署不同版本的业务功能模块

### 架构图

<img src="https://github.com/gongap/KissU/blob/master/architecture.png" alt="架构图" />

### 调用链

<img src="https://github.com/gongap/KissU/blob/master/call-chain.png" alt="链路图" />


### 文件配置：

```c#
{
  "ConnectionString": "${Register_Conn}|127.0.0.1:8500", // ${环境变量名} |默认值,
  "SessionTimeout": "${Register_SessionTimeout}|50",
  "ReloadOnChange": true
}

```

### 非容器环境文件配置

```c#
 {
  "Ip": "${Server_IP}|127.0.0.1",
  "WatchInterval": 30,
  "Port": "${Server_port}",
  "Token": "true",
   "Protocol": "${Protocol}|Tcp", //支持Http,Tcp协议
  "RootPath": "${RootPath}",
  "RequestCacheEnabled": false
}

```


### 容器环境文件配置

```c#
 {
  "Ip": "${Server_IP}|0.0.0.0",//私有容器IP
  "WatchInterval": 30,
  "Port": "${Server_port}|98",//私有容器端口
   "MappingIp": "${Mapping_ip}",//公开主机IP
  "MappingPort": "${Mapping_Port}",//公开主机端口
   "Protocol": "${Protocol}|Tcp", //支持Http,Tcp协议
  "Token": "true",
  "RootPath": "${RootPath}",
  "RequestCacheEnabled": false
}

```


服务路由访问配置：
<br/>

```c#
[ServiceBundle("api/{Service}")]
 ```    
<br/>

JWT验证，接口方法添加以下特性：
<br/>

```c#
   [Authorization(AuthType = AuthorizationType.JWT)];
 ```    
<br/>

AppSecret验证，接口方法添加以下特性：
<br/>

```c#
 [Authorization(AuthType = AuthorizationType.AppSecret)];
 ```    
<br/>

订阅功能：
<br/>

```c#
 ServiceLocator.GetService< ISubscriptionAdapt >().SubscribeAt();
 ```    
 
 <br/>
增加服务容错、服务容错降级、服务强制降级


* 增加容错策略Injection，脚本注入：

<br/>

```c#
[Command(Strategy= StrategyType.Injection ,Injection = @"return null;")]
```    

 <br/>
 
```C#  
[Command(Strategy= StrategyType.Injection ,Injection = @"return 
Task.FromResult(new Surging.IModuleServices.Common.Models.UserModel
         {
            Name=""fanly"",
            Age=18
         });",InjectionNamespaces =new string[] { "Surging.IModuleServices.Common"})] 
```


* 增加容错策略Injection，本地模块注入：   

<br/>

```C#  
[Command(Strategy= StrategyType.Injection ,Injection = @"return true;")] 
```

<br/>

增加缓存降级，怎么使用？
<br/>
在业务接口方法上添加如下特性
<br/>

```C#  
   [Command(Strategy= StrategyType.Failover,FailoverCluster =3,RequestCacheEnabled =true)]  //RequestCacheEnabled =true 就是启用缓存
```

<br/>
怎么拦截获取缓存
 <br/>
在业务接口方法上添加如下特性
 <br/>
 
```C#  
 [InterceptMethod(CachingMethod.Get, Key = "GetUser_id_{0}", Mode = CacheTargetType.Redis, Time = 480)]
```
    
<br/>
怎么拦截删除缓存
 <br/>
在业务接口方法上添加如下特性
 <br/>
 
```C#  
  [InterceptMethod(CachingMethod.Remove, "GetUser_id_{0}", "GetUserName_name_{0}", Mode = CacheTargetType.Redis)]
```
      
<br/>
怎么添加缓存KEY
   <br/>
在业务模型属性上添加，如下特性，可以支持多个
   <br/>
   
```C# 
[CacheKey(1)]
```
        
<br/>
配置拦截器
<br/>
   
```C# 
 .AddClientIntercepted(typeof(CacheProviderInterceptor))
``
