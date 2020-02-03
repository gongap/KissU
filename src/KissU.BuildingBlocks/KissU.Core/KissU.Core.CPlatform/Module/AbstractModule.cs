using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Autofac;
using KissU.Core.CPlatform.Exceptions;

namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 抽象模块
    /// </summary>
    public abstract class AbstractModule : Autofac.Module, IDisposable
    {
        /// <summary>
        /// 容器创建包装属性
        /// </summary>
        public ContainerBuilderWrapper Builder { get; set; }

        /// <summary>
        /// 唯一标识guid
        /// </summary>
        public Guid Identifier { get; set; }

        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 类型名
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否可用（控制模块是否加载）
        /// </summary>
        public bool Enable { get; set; } = true;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        public List<Component> Components { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractModule" /> class.
        /// 初始化
        /// </summary>
        public AbstractModule()
        {
            ModuleName = this.GetType().Name;
            TypeName = this.GetType().BaseType?.Name;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public virtual void Initialize(AppModuleContext serviceProvider)
        {
            Dispose();
        }

        /// <summary>
        /// 重写将注册添加到容器，判断组件是否可用，并注册模块组件
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        /// <exception cref="KissU.Core.CPlatform.Exceptions.CPlatformException"></exception>
        /// <exception cref="CPlatformException">基础异常类</exception>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                base.Load(builder);
                Builder = new ContainerBuilderWrapper(builder);

                // 如果可用
                if (Enable)
                {
                    // 注册创建容器
                    RegisterBuilder(Builder);

                    // 注册组件
                    RegisterComponents(Builder);
                }
            }
            catch (Exception ex)
            {
                throw new CPlatformException(string.Format("注册模块组件类型时发生错误：{0}", ex.Message));
            }
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected virtual void RegisterBuilder(ContainerBuilderWrapper builder)
        {
        }

        /// <summary>
        /// 注册组件
        /// </summary>
        /// <param name="builder">构建器包装</param>
        internal virtual void RegisterComponents(ContainerBuilderWrapper builder)
        {
            Components?.ForEach(component =>
            {
                // 服务类型
                Type serviceType = Type.GetType(component.ServiceType, true);

                // 实现类型
                Type implementType = Type.GetType(component.ImplementType, true);

                // 组件生命周期
                switch (component.LifetimeScope)
                {
                    // 依赖创建
                    case LifetimeScope.InstancePerDependency:

                        // 如果是泛型
                        if (serviceType.GetTypeInfo().IsGenericType || implementType.GetTypeInfo().IsGenericType)
                        {
                            // 注册泛型
                            builder.RegisterGeneric(implementType).As(serviceType).InstancePerDependency();
                        }
                        else
                        {
                            builder.RegisterType(implementType).As(serviceType).InstancePerDependency();
                        }

                        break;
                    case LifetimeScope.SingleInstance:
                        // 单例
                        if (serviceType.GetTypeInfo().IsGenericType || implementType.GetTypeInfo().IsGenericType)
                        {
                            builder.RegisterGeneric(implementType).As(serviceType).SingleInstance();
                        }
                        else
                        {
                            builder.RegisterType(implementType).As(serviceType).SingleInstance();
                        }

                        break;
                    default:
                        // 默认依赖创建
                        if (serviceType.GetTypeInfo().IsGenericType || implementType.GetTypeInfo().IsGenericType)
                        {
                            builder.RegisterGeneric(implementType).As(serviceType).InstancePerDependency();
                        }
                        else
                        {
                            builder.RegisterType(implementType).As(serviceType).InstancePerDependency();
                        }

                        break;
                }
            });
        }

        /// <summary>
        /// 验证模块
        /// </summary>
        /// <exception cref="KissU.Core.CPlatform.Exceptions.CPlatformException">模块属性：Identifier，ModuleName，TypeName，Title 是必须的不能为空！</exception>
        /// <exception cref="KissU.Core.CPlatform.Exceptions.CPlatformException">模块属性：ModuleName 必须为字母开头数字或下划线的组合！</exception>
        /// <exception cref="CPlatformException">模块属性：Identifier，ModuleName，TypeName，Title 是必须的不能为空！</exception>
        /// <exception cref="CPlatformException">模块属性：ModuleName 必须为字母开头数字或下划线的组合！</exception>
        public virtual void ValidateModule()
        {
            if (this.Identifier == Guid.Empty || string.IsNullOrEmpty(this.ModuleName) || string.IsNullOrEmpty(this.TypeName)
                || string.IsNullOrEmpty(this.Title))
            {
                throw new CPlatformException("模块属性：Identifier，ModuleName，TypeName，Title 是必须的不能为空！");
            }

            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9_]*$");
            if (!regex.IsMatch(this.ModuleName))
            {
                throw new CPlatformException("模块属性：ModuleName 必须为字母开头数字或下划线的组合！");
            }
        }

        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("标识符：{0}", Identifier);
            sb.AppendLine();
            sb.AppendFormat("模块名：{0}", ModuleName);
            sb.AppendLine();
            sb.AppendFormat("类型名：{0}", TypeName);
            sb.AppendLine();
            sb.AppendFormat("标题：{0}", Title);
            sb.AppendLine();
            sb.AppendFormat("描述：{0}", Description);
            sb.AppendLine();
            sb.AppendFormat("组件详细 {0}个", Components.Count);
            sb.AppendLine();
            Components.ForEach(c =>
            {
                sb.AppendLine(c.ToString());
            });
            return sb.ToString();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}