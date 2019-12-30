using System;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServer4.Stores.Serialization;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.IdentityServer.Data.Stores
{
    /// <summary>
    /// 设备流存储器
    /// </summary>
    /// <seealso cref="IDeviceFlowStore" />
    public class DeviceFlowStore : IDeviceFlowStore
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        protected readonly ILogger Logger;

        /// <summary>
        /// 仓储
        /// </summary>
        protected readonly IDeviceFlowCodeRepository Repository;

        /// <summary>
        /// 序列化程序
        /// </summary>
        protected readonly IPersistentGrantSerializer Serializer;

        /// <summary>
        /// 工作单元
        /// </summary>
        protected readonly IIdentityServerUnitOfWork UnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceFlowStore" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork.</param>
        /// <param name="repository">The context.</param>
        /// <param name="serializer">The serializer</param>
        /// <param name="logger">The logger.</param>
        public DeviceFlowStore(
            IIdentityServerUnitOfWork unitOfWork,
            IDeviceFlowCodeRepository repository,
            IPersistentGrantSerializer serializer,
            ILogger<DeviceFlowStore> logger)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            Serializer = serializer;
            Logger = logger;
        }

        /// <summary>
        /// 存储设备授权请求
        /// </summary>
        /// <param name="deviceCode">The device code.</param>
        /// <param name="userCode">The user code.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public virtual async Task StoreDeviceAuthorizationAsync(string deviceCode, string userCode, DeviceCode data)
        {
            await Repository.AddAsync(ToEntity(data, deviceCode, userCode));

            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 按用户代码查找设备授权
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <returns></returns>
        public virtual async Task<DeviceCode> FindByUserCodeAsync(string userCode)
        {
            var deviceFlowCodes = await Repository.Find(x => x.UserCode == userCode).FirstOrDefaultAsync();
            var model = ToModel(deviceFlowCodes?.Data);

            Logger.LogDebug("{userCode} found in database: {userCodeFound}", userCode, model != null);

            return model;
        }

        /// <summary>
        /// 根据设备代码查找设备授权
        /// </summary>
        /// <param name="deviceCode">The device code.</param>
        /// <returns></returns>
        public virtual async Task<DeviceCode> FindByDeviceCodeAsync(string deviceCode)
        {
            var deviceFlowCodes = await Repository.SingleAsync(x => x.DeviceCode == deviceCode);
            var model = ToModel(deviceFlowCodes?.Data);

            Logger.LogDebug("{deviceCode} found in database: {deviceCodeFound}", deviceCode, model != null);

            return model;
        }

        /// <summary>
        /// 按用户代码更新设备授权
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public virtual async Task UpdateByUserCodeAsync(string userCode, DeviceCode data)
        {
            var existing = await Repository.Find(x => x.UserCode == userCode).FirstOrDefaultAsync();
            if (existing == null)
            {
                Logger.LogError("{userCode} not found in database", userCode);
                throw new InvalidOperationException("Could not update device code");
            }

            var entity = ToEntity(data, existing.DeviceCode, userCode);
            Logger.LogDebug("{userCode} found in database", userCode);

            existing.SubjectId = data.Subject?.FindFirst(JwtClaimTypes.Subject).Value;
            existing.Data = entity.Data;

            try
            {
                await UnitOfWork.CommitAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Logger.LogWarning("exception updating {userCode} user code in database: {error}", userCode, ex.Message);
            }
        }

        /// <summary>
        /// 按设备代码删除设备授权
        /// </summary>
        /// <param name="deviceCode">The device code.</param>
        /// <returns></returns>
        public virtual async Task RemoveByDeviceCodeAsync(string deviceCode)
        {
            var deviceFlowCodes = await Repository.SingleAsync(x => x.DeviceCode == deviceCode);

            if (deviceFlowCodes != null)
            {
                Logger.LogDebug("removing {deviceCode} device code from database", deviceCode);

                await Repository.RemoveAsync(deviceFlowCodes);

                try
                {
                    await UnitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Logger.LogInformation("exception removing {deviceCode} device code from database: {error}",
                        deviceCode, ex.Message);
                }
            }
            else
            {
                Logger.LogDebug("no {deviceCode} device code found in database", deviceCode);
            }
        }

        /// <summary>
        /// 将模型转换为实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="deviceCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        protected DeviceFlowCode ToEntity(DeviceCode model, string deviceCode, string userCode)
        {
            if (model == null || deviceCode == null || userCode == null) return null;

            return new DeviceFlowCode
            {
                DeviceCode = deviceCode,
                UserCode = userCode,
                ClientId = model.ClientId,
                SubjectId = model.Subject?.FindFirst(JwtClaimTypes.Subject).Value,
                CreationTime = model.CreationTime,
                Expiration = model.CreationTime.AddSeconds(model.Lifetime),
                Data = Serializer.Serialize(model)
            };
        }

        /// <summary>
        /// 将序列化的设备代码转换为模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected DeviceCode ToModel(string entity)
        {
            if (entity == null) return null;

            return Serializer.Deserialize<DeviceCode>(entity);
        }
    }
}