# AdminConsole
AdminConsole 是一种尝试采用微服务开发风格的主题，每个服务相当独立的小型Angular应用，希望通过开发规范约定之下可以更好交付整合。主题重新定制整个 ng-zorro-antd 组件风格，在此基础上优化一些组件的视觉体验。除 ng-zorro-antd、@delon 组件库以外，包含更多秉承 Ant Design 的设计价值观的组件设计。

快速入门
----

**前置条件**

安装 [Node](https://nodejs.org/)、[Yarn](https://yarnpkg.com/)。

**运行**

1、下载最新完整项目源文件。

2、切换至根目录并安装依赖包。

    yarn

3、启动

    ng serve
    # 或 hmr 模式
    npm run hmr

4、构建

    npm run build

如何开发
----

主要目录结构: 你可以把它看成一个大的 Angular 项目，每个服务独自一个文件夹，例如 `account` 服务结构如下：

    account
    ├── _i18n                     # UI语言
    ├── _layout                   # 服务布局
    ├── _core                     # 服务共享服务
    ├── _shared                   # 服务共享模块
    ├── login                     # 具体业务
    │   ├── login.component.html
    │   └── login.component.ts
    ├── account-routing.module.ts # 服务注册口
    └── account.module.ts         # 服务模块

服务目录结构如同一个完整的 Angular 项目，但它只包含服务应有的文件。

开发指南
----

为了实现**每个服务都应该被独立**这一方向，我们制定了一些约定，并不是要求你完全按照这些约定执行，只是作为一个范本。

### 1、每个服务应独立仓储

我们把一个具有完整的 Angular 项目作为每个服务的开发模板称为**公共项目**，不必担心维护成本，利用 Git Submodule 非常方便的维护它们。

*   公共项目只允许一个人来维护，其他成员只读权限
*   公共项目应该至少包含能运行服务基本要素，例如：异常页、登录入口。

一个简单示例，可以移除主题示例页（指 `routes` 目录），仅包含 `exception`、`account`、`routes-routing.module.ts`、`routes.module.ts` 四项做为公共项目。

### 2、共享组件、服务等应使用路径映射

默认配置了三个主要目录的映射：

*   `@shared` 共享模块，指向 `src/app/shared/index` 文件
*   `@core` 核心模块，指向 `src/app/core/index` 文件
*   `@brand` MS主题模块，指向 `src/app/layout/ms/index` 文件

若服务需要访问这些共享目录都必须采用映射路径，例如访问 `BrandService` 服务：

    import { BrandService } from '@brand';

甚至可以更严格要求只允许通过 `@brand` 而非 `@brand/ms.service` 具体路径，通过 `index.ts` 可以更好的规范哪些共享信息可被使用。

### 3、国际化

国际化应该分为UI、API两个部分。

*   UI 应统一由 `_i18n` 来维护，并且在模块初始化进行加载，参考 `account.module.ts`
    *   统一在模板中使用 `| i18n` 管道，它是 ng-alain 内置的一部分
*   API 应统一由网关根据请求参数自动翻译，每个请求默认在 `header` 包含 `lang` 为当前语言代码，参考 `default.interceptor.ts`

### 4、服务布局

当服务自身需要菜单时，应提供布局组件。

默认MS主题包含了 [service-layout](service-layout) 组件可以快速构建类似 DNS 示例的服务菜单，菜单数据应该符合 ng-alain 的 [MenuService](https://ng-alain.com/theme/menu) 标准，具体参考 `dns/_layout/layout.component.ts` 和次级导航 `dns/_layout/layout-settings.component.ts`。

服务开发
----

每个服务都应该被独立存储，意味着每个服务的开发成员需要单独在本地构建一个完整的 Angular 项目，透过 Git Submodule 可以非常容易实现；以 `home` 服务示例。

### 1、创建新服务

创建服务需要在公共项目注册懒模块：

    // routes-routing.module.ts
    { path: 'home', loadChildren: './home/home.module#HomeModule' },

如果有CI&CD部署则需要增加 Git Clone 指令，例如在 `.gitlab-ci.yml` 增加：

    - git clone --depth 1 https://username:password@gitlab.com/demo/home.git src/app/routes/home

### 2、开发人员

公共项目仓储与服务仓储的合并可以组成一个有效的 Angular 项目，对于开发人员只需要简单几个步骤：

    $ git clone --depth 1 https://gitlab.com/demo/ms.git
    $ cd ms
    $ npm run new-dev

部署
--

基于上述如何开发与约定指南，可以非常简单在公共项目中编写CI&CD脚本，我们提供一个 `.gitlab-ci.yml` 脚本，可以快速实现 CI & CD。
