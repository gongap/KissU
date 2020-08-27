# KissU框架介绍 

<blockquote>
"作为面向服务架构(SOA)的一个变体,微服务是一种将应用程序分解成松散耦合服务的新型架构风格. 通过细粒度的服务和轻量级的协议,微服务提供了更多的模块化,使应用程序更容易理解,开发,测试,并且更容易抵抗架构侵蚀. 它使小型团队能够开发,部署和扩展各自的服务,实现开发的并行化.它还允许通过连续重构形成单个服务的架构. 基于微服务架构可以实现持续交付和部署."
KissU 框架的主要目标之一就是提供便捷的基础设施来创建微服务解决方案.
</blockquote>

> 源码路径：[源代码 ***C#***](https://github.com/gongap/KissU)

> 示例解决方案：[源代码 ***C#***](https://github.com/gongap/KissU.Microservice)

## 文档目录

> 本文档会持续更新

- [概述](docs/zh-Hans/Index.md)
  - [入门](docs/zh-Hans/Getting-Started.md)
  - [路线图](docs/zh-Hans/Road-Map.md)
- 教程
  - 服务主机如何构建
    - 依赖注入服务
    - 配置日志组件
    - 如何设置成服务提供者
    - 启动配置
    - 配置文件构建
  - 协议主机构建
    - 构建TCP协议服务主机
    - 构建MQTT协议服务主机
    - 构建WS协议服务主机
    - 构建UDP协议服务主机
    - 构建Http协议服务主机
    - 构建Dns协议服务主机
  - 如何构建微服务
    - 微服务规则
    - 配置routepath
    - 配置ServiceMetadata
    - 服务拦截器配置
    - 配置依赖注入
    - 如何配置和读取配置项
  - 服务注册发现和服务治理
    - consul的注册与发现
    - zookeeper的注册与发现
    - 服务路由的负载均衡
    - 容错策略
    - 服务熔断
  - 引擎核心组件
    - 配置使用Swagger组件
    - 配置ProtoBuffer、MessagePack或Json.net组件编解码消息
    - 配置Log4net日志组件
    - 配置NLog日志组件
    - 配置Stage关卡组件
    - 配置扩展SystemModule组件
    - 配置扩展BusinessModule组件
    - 配置扩展EnginePartModule组件
    - 配置扩展KestrelHttpModule组件
  - 中间件
    - 缓存中间件
    - 消息中间件
  - 网关
    - 配置gatewaySettings.json文件
    - jwt鉴权
    - 基于Stage生成的第三方接口网关
  - 示例
    - 缓存中间件使用
    - 消息中间件使用
    - 服务之间本地和远程调用
  - 部署
    - 引擎部署到window环境中
    - 引擎部署到linux环境容器中
    - 引擎构建镜像push到镜像库
    - 扫描业务模块组件和中间件装载到引擎中
    - 基于rancher 服务编排

## 框架由来

KissU是一个**开源微服务框架**, 在 [Surging](https://github.com/fanliang11/surging), [ABP](https://github.com/abpframework/abp) 等众多优秀开源项目基础上整合出的一套专注于基于.NET Core的微服务开发框架.

[Surging](https://github.com/fanliang11/surging) 是一个**分布式微服务引擎**,提供高性能RPC远程服务调用，服务引擎支持http、TCP、WS、Mqtt协议,采用Zookeeper、Consul作为surging服务的注册中心，集成了哈希一致性，随机，轮询、压力最小优先作为负载均衡的算法，底层协议集成采用的组件是dotnetty、websocket-sharp、Kestrel.

[ABP](https://github.com/abpframework/abp) 是一个**开源应用程序框架**,专注于基于ASP.NET Core的Web应用程序开发,但也支持开发其他类型的应用程序.

框架是一种可复用的基础代码库，如果它只解决纯技术问题，可以认为是技术框架，如果它与你的业务相关，则可认为是应用框架（框架，应用框架均没有标准定义，我在此以个人理解描述术语含义，以方便后续讨论，并非权威定义）。

Surging提供的基础类库是最基础的微服务技术框架，Abp基于DDD的经典分层架构思想，实现了众多DDD的概念。KissU将这两个框架结合，利用Surging提供微服务的基础设施，Abp实现具体的服务内部业务逻辑，提供基础设施来实现微服务中的领域驱动设计.

发布KissU的目的，是希望帮助技术还比较落后的.net团队能够搭建出自己的微服务框架，提供一个示范，同时也希望它成为跟我有相似开发习惯和偏好的.net同学的重要工具。

## 贡献与反馈

> 如果你在阅读或使用发现Bug，或有更佳实现方式，请通知我们。

> 为了保持代码简单，目前很多功能只建立了基本结构，细节特性未进行迁移，在后续需要时进行添加，如果你发现某个类无法满足你的需求，请通知我们。

> 你可以通过github的Issue或Pull Request向我们提交问题和代码，如果你更喜欢使用QQ进行交流，请加入我们的交流QQ群。

> 对于你提交的代码，如果我们决定采纳，可能会进行相应重构，以统一代码风格。

> 对于热心的同学，将会把你的名字放到**贡献者**名单中。

> KissU是一个社区驱动的开源项目.如果你想成为该项目的一部分,请参阅[贡献指南](docs/zh-Hans/Contribution/Index.md)。
    
## 免责申明

- 虽然我们对代码已经进行高度审查，并用于自己的项目中，但依然可能存在某些未知的BUG，如果你的生产系统蒙受损失，KissU团队不会对此负责。

- 出于成本的考虑，我们不会对已发布的API保持兼容，每当更新代码时，请注意该问题。
