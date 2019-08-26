using System;
using System.Linq;
using System.Threading.Tasks;
using KissU.IModuleServices.GreatWall.Abstractions;
using KissU.IModuleServices.GreatWall.Dtos;
using KissU.IModuleServices.GreatWall.Dtos.Requests;
using KissU.IModuleServices.GreatWall.Service.Queries;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using Util;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Maps;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : DeleteServiceBase<User, UserDto, UserQuery>, IUserService
    {
        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userRepository">用户仓储</param>
        /// <param name="userManager">用户服务</param>
        public UserService(IGreatWallUnitOfWork unitOfWork, IUserRepository userRepository, IUserManager userManager)
            : base(unitOfWork, userRepository)
        {
            UnitOfWork = unitOfWork;
            UserRepository = userRepository;
            UserManager = userManager;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 用户仓储
        /// </summary>
        public IUserRepository UserRepository { get; set; }
        /// <summary>
        /// 用户服务
        /// </summary>
        public IUserManager UserManager { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<User> CreateQuery(UserQuery param)
        {
            return new Query<User>(param)
                .WhereIfNotEmpty(t => t.UserName.Contains(param.UserName))
                .WhereIfNotEmpty(t => t.PhoneNumber.Contains(param.PhoneNumber))
                .WhereIfNotEmpty(t => t.Email.Contains(param.Email));
        }

        /// <summary>
        /// 过滤查询
        /// </summary>
        protected override IQueryable<User> Filter(IQueryable<User> queryable, UserQuery parameter)
        {
            if (parameter.RoleId != null)
                return UserRepository.FilterByRole(queryable, parameter.RoleId.SafeValue());
            if (parameter.ExceptRoleId != null)
                return UserRepository.FilterByRole(queryable, parameter.ExceptRoleId.SafeValue(), true);
            return queryable;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        public async Task<Guid> CreateAsync(CreateUserRequest request)
        {
            var user = request.MapTo<User>();
            user.Enabled = true;
            await UserManager.CreateAsync(user, request.Password);
            await UnitOfWork.CommitAsync();
            return user.Id;
        }
    }
}