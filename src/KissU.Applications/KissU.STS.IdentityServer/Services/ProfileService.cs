using Util.Security.Claims;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Services.Implements;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Util;

namespace KFNets.Microservices.IdentityServer.Services
{
    /// <summary>
    /// 自定义ProfileService
    /// </summary>
    public class ProfileService : ProfileService<User>, IProfileService
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="userManager">用户管理器</param>
        /// <param name="claimsFactory">证件当事人工厂</param>
        /// <param name="clientRepository">应用程序仓储</param>
        /// <param name="userRepository">用户仓储</param>
        /// <param name="roleRepository">角色仓储</param>
        /// <param name="organizationRepository">组织机构仓储</param>
        /// <param name="enterpriseRepository">企业仓储</param>
        /// <param name="permissionRepository">权限仓储</param>
        public ProfileService(IdentityUserManager userManager, IUserClaimsPrincipalFactory<User> claimsFactory,
            IClientRepository clientRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IOrganizationRepository organizationRepository,
            IEnterpriseRepository enterpriseRepository,
            IPermissionRepository permissionRepository) : base(userManager, claimsFactory)
        {
            UserManager = userManager;
            ClientRepository = clientRepository ?? throw new System.ArgumentNullException(nameof(clientRepository));
            UserRepository = userRepository ?? throw new System.ArgumentNullException(nameof(userRepository));
            RoleRepository = roleRepository ?? throw new System.ArgumentNullException(nameof(roleRepository));
            OrganizationRepository = organizationRepository ?? throw new System.ArgumentNullException(nameof(organizationRepository));
            EnterpriseRepository = enterpriseRepository ?? throw new System.ArgumentNullException(nameof(enterpriseRepository));
            PermissionRepository = permissionRepository ?? throw new System.ArgumentNullException(nameof(permissionRepository));
        }

        /// <summary>
        /// 用户管理器
        /// </summary>
        public IdentityUserManager UserManager { get; }
        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IClientRepository ClientRepository { get; }
        /// <summary>
        /// 用户仓储
        /// </summary>
        public IUserRepository UserRepository { get; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; }
        /// <summary>
        /// 组织机构仓储
        /// </summary>
        public IOrganizationRepository OrganizationRepository { get; }
        /// <summary>
        /// 企业仓储
        /// </summary>
        public IEnterpriseRepository EnterpriseRepository { get; }
        /// <summary>
        /// 权限仓储
        /// </summary>
        public IPermissionRepository PermissionRepository { get; }

        /// <summary>
        /// 只要有关用户的身份信息单元被请求（例如在令牌创建期间或通过用户信息终点），就会调用此方法
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override async  Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await base.GetProfileDataAsync(context);

            var claims = new List<System.Security.Claims.Claim>();

            //判断是否有请求Claim信息
            if (context.RequestedClaimTypes.Any())
            {
                //根据用户唯一标识查找用户信息
                var user = await UserManager.FindByIdAsync(context.Subject.GetSubjectId());
                if (user != null)
                {
                    //添加企业声明
                    var enterprise = await EnterpriseRepository.GetDefaultEnterpriseByUserIdAsync(user.Id);
                    if (enterprise == null)
                    {
                        enterprise = (await EnterpriseRepository.GetEnterpriseByUserIdAsync(user.Id)).FirstOrDefault();
                    }
                    if (enterprise != null)
                    {
                        claims.Add(new System.Security.Claims.Claim(Util.Security.Claims.Extension.ClaimTypes.EnterpriseId, enterprise.Id.SafeString()));
                        claims.Add(new System.Security.Claims.Claim(Util.Security.Claims.ClaimTypes.TenantId, enterprise.TenantId.SafeString()));
                        claims.Add(new System.Security.Claims.Claim("tenant_wcf", enterprise.WcfAddress.SafeString()));
                    }
                    else
                    {
                        claims.Add(new System.Security.Claims.Claim("tenant_id", user.Id.SafeString()));
                    }

                    //添加权限声明
                    var permissions = await PermissionRepository.GetPermissionsAsync(user.Id, PermissionType.User);
                    if (permissions?.Count > 0)
                    {
                        claims.Add(new System.Security.Claims.Claim("permission", permissions.Select(t => t.Code).ToList().Join()));
                    }
                }
            }

            context.AddRequestedClaims(claims);
        }
    }
}
