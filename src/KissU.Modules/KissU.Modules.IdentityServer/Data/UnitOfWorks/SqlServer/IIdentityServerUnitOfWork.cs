using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Util.Domains;
using Util.Reflections;

namespace KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class IdentityServerUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, UnitOfWorks.IIdentityServerUnitOfWork
    {
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly IFind _finder;

        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="finder">类型查找器</param>
        /// <param name="tenantProvider">租户提供程序</param>
        /// <param name="enterpriseProvider">企业提供程序</param>
        public IdentityServerUnitOfWork(DbContextOptions<IdentityServerUnitOfWork> options, IServiceProvider serviceProvider, IFind finder) : base(options, serviceProvider)
        {
            _finder = finder ?? new Finder();
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected override Assembly[] GetAssemblies()
        {
            return _finder.GetAssemblies().ToArray();
        }

        /// <summary>
        /// 配置映射
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureFilters(modelBuilder);

        }

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        protected override void InterceptAddedOperation(EntityEntry entry)
        {
            base.InterceptAddedOperation(entry);
            AddTenantIntercept(entry.Entity);
            AddEnterpriseIntercept(entry.Entity);
        }

        /// <summary>
        /// 拦截删除操作
        /// </summary>
        /// <param name="entry"></param>
        protected override void InterceptDeletedOperation(EntityEntry entry)
        {
            base.InterceptDeletedOperation(entry);
            AddStaticIntercept(entry.Entity);
        }

        /// <summary>
        /// 拦截更新操作
        /// </summary>
        /// <param name="entry"></param>
        protected override void InterceptModifiedOperation(EntityEntry entry)
        {
            base.InterceptModifiedOperation(entry);
            if (entry.Entity is IDelete model && model.IsDeleted)
                AddStaticIntercept(entry.Entity);
        }

        /// <summary>
        /// 添加系统内置静态资源拦截器
        /// </summary>
        protected virtual void AddStaticIntercept(object entity)
        {
        }

        /// <summary>
        /// 添加租户拦截器
        /// </summary>
        protected virtual void AddTenantIntercept(object entity)
        {
            //var tenantId = _tenantProvider.GetTenantId();
            //if (entity is IMayHaveTenant mayHaveTenant)
            //{
            //    mayHaveTenant.TenantId = tenantId;
            //}
            //if (entity is IMustHaveTenant mustHaveTenant)
            //{
            //    if (tenantId.HasValue && !tenantId.IsEmpty())
            //    {
            //        mustHaveTenant.TenantId = tenantId.Value;
            //    }
            //    else
            //    {
            //        throw new Warning("Can not set TenantId to null for ITenant entities!");
            //    }
            //}
        }

        /// <summary>
        /// 添加企业拦截器
        /// </summary>
        protected virtual void AddEnterpriseIntercept(object entity)
        {
            //var enterpriseId = _enterpriseProvider.GetEnterpriseId();
            //if (entity is IMayHaveEnterprise mayHaveEnterprise)
            //{
            //    mayHaveEnterprise.EnterpriseId = enterpriseId;
            //}
            //if (entity is IMustHaveEnterprise mustHaveEnterprise)
            //{
            //    if (enterpriseId.HasValue && !enterpriseId.IsEmpty())
            //    {
            //        mustHaveEnterprise.EnterpriseId = enterpriseId.Value;
            //    }
            //    else
            //    {
            //        throw new Warning("Can not set EnterpriseId to null for IEnterprise entities!");
            //    }
            //}
        }

        /// <summary>
        /// 配置过滤条件
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected virtual void ConfigureFilters(ModelBuilder modelBuilder)
        {
        }
    }
}