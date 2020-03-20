﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util;
using KissU.Util.Datas.Ef.Core;
using Microsoft.AspNetCore.Identity;

namespace KissU.Modules.GreatWall.Data.Repositories
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository, IUserPasswordStore<User>,
        IUserSecurityStampStore<User>, IUserLockoutStore<User>, IUserEmailStore<User>, IUserPhoneNumberStore<User>
    {
        /// <summary>
        /// 初始化用户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public UserRepository(IGreatWallUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 设置电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="email">电子邮件</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.Email = email;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The task object containing the results of the asynchronous operation, the email address for the specified
        /// <paramref name="user" />.
        /// </returns>
        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.Email);
        }

        /// <summary>
        /// 获取电子邮件确认状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The task object containing the results of the asynchronous operation, a flag indicating whether the email address for
        /// the specified <paramref name="user" />
        /// has been confirmed or not.
        /// </returns>
        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.EmailConfirmed);
        }

        /// <summary>
        /// 确认电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="confirmed">是否确认</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.EmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 通过电子邮件查找
        /// </summary>
        /// <param name="normalizedEmail">标准化电子邮件</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The task object containing the results of the asynchronous lookup operation, the user if any associated with
        /// the specified normalized email address.
        /// </returns>
        public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await SingleAsync(u => u.NormalizedEmail == normalizedEmail, cancellationToken);
        }

        /// <summary>
        /// 获取标准化电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The task object containing the results of the asynchronous lookup operation, the normalized email address if
        /// any associated with the specified user.
        /// </returns>
        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.NormalizedEmail);
        }

        /// <summary>
        /// 设置标准化电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="normalizedEmail">标准化电子邮件</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.NormalizedEmail = normalizedEmail;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取锁定结束日期
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a
        /// <see cref="T:System.DateTimeOffset" /> containing the last time
        /// a user's lockout expired, if any.
        /// </returns>
        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.LockoutEnd);
        }

        /// <summary>
        /// 设置锁定结束日期
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="lockoutEnd">锁定结束日期</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        public Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.LockoutEnd = lockoutEnd;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 增加访问失败次数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// incremented failed access count.
        /// </returns>
        public Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.AccessFailedCount = user.AccessFailedCount.SafeValue() + 1;
            return Task.FromResult(user.AccessFailedCount.SafeValue());
        }

        /// <summary>
        /// 重置访问失败次数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        /// <remarks>This is typically called after the account is successfully accessed.</remarks>
        public Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.AccessFailedCount = 0;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取登录失败次数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// failed access count.
        /// </returns>
        public Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.AccessFailedCount.SafeValue());
        }

        /// <summary>
        /// 获取锁定启用状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, true if a user
        /// can be locked out, otherwise false.
        /// </returns>
        public Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.LockoutEnabled);
        }

        /// <summary>
        /// 设置锁定启用状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="enabled">是否启用锁定</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        public Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.LockoutEnabled = enabled;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// identifier for the specified <paramref name="user" />.
        /// </returns>
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.Id.SafeString());
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// name for the specified <paramref name="user" />.
        /// </returns>
        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.UserName);
        }

        /// <summary>
        /// 设置用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.UserName = userName;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取标准化用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// normalized user name for the specified <paramref name="user" />.
        /// </returns>
        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.NormalizedUserName);
        }

        /// <summary>
        /// 设置标准化用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="normalizedName">标准化用户名</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the creation operation.
        /// </returns>
        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            Add(user);
            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the update operation.
        /// </returns>
        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            await UpdateAsync(user);
            return IdentityResult.Success;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the update operation.
        /// </returns>
        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            await RemoveAsync(user, cancellationToken);
            return IdentityResult.Success;
        }

        /// <summary>
        /// 根据标识查找
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// user matching the specified <paramref name="userId" /> if it exists.
        /// </returns>
        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return FindAsync(userId.ToGuid(), cancellationToken);
        }

        /// <summary>
        /// 通过用户名查找
        /// </summary>
        /// <param name="normalizedUserName">标准化用户名</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// user matching the specified <paramref name="normalizedUserName" /> if it exists.
        /// </returns>
        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return SingleAsync(t => t.NormalizedUserName == normalizedUserName, cancellationToken);
        }

        /// <summary>
        /// 设置密码散列
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="passwordHash">密码散列</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取密码散列
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning the
        /// password hash for the specified <paramref name="user" />.
        /// </returns>
        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PasswordHash);
        }

        /// <summary>
        /// 是否设置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the
        /// specified <paramref name="user" /> has a password
        /// otherwise false.
        /// </returns>
        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PasswordHash.IsEmpty() == false);
        }

        /// <summary>
        /// 设置手机号
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.PhoneNumber = phoneNumber;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the
        /// user's telephone number, if any.
        /// </returns>
        public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PhoneNumber);
        }

        /// <summary>
        /// 获取手机号确认状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the
        /// specified <paramref name="user" /> has a confirmed
        /// telephone number otherwise false.
        /// </returns>
        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        /// <summary>
        /// 设置手机号确认状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="confirmed">是否确认</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.PhoneNumberConfirmed = confirmed;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 过滤角色
        /// </summary>
        /// <param name="queryable">查询对象</param>
        /// <param name="roleId">角色标识</param>
        /// <param name="except">是否排除该角色的用户列表</param>
        /// <returns>IQueryable&lt;User&gt;.</returns>
        public IQueryable<User> FilterByRole(IQueryable<User> queryable, Guid roleId, bool except = false)
        {
            if (roleId.IsEmpty())
                return queryable;
            var selectedUsers = from user in queryable
                join userRole in UnitOfWork.Set<UserRole>() on user.Id equals userRole.UserId
                where userRole.RoleId == roleId
                select user;
            if (except)
                return queryable.Except(selectedUsers);
            return selectedUsers;
        }

        /// <summary>
        /// 设置安全戳
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="stamp">安全戳</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">stamp</exception>
        public Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            if (string.IsNullOrWhiteSpace(stamp))
                throw new ArgumentNullException(nameof(stamp));
            user.SecurityStamp = stamp;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取安全戳
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public Task<string> GetSecurityStampAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.SecurityStamp);
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        private void ValidateUser(User user, CancellationToken cancellationToken)
        {
            user.CheckNull(nameof(user));
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}