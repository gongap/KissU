using System.Threading.Tasks;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.Models;
using Volo.Abp.Identity;

namespace KissU.Modules.Account.Service.Contracts
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IProfileService : IServiceKey
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>Task&lt;ProfileDto&gt;.</returns>
        [HttpGet(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<ProfileDto> Get();

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;ProfileDto&gt;.</returns>
        [HttpPost(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<ProfileDto> Update(UpdateProfileDto parameters);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task ChangePassword(ChangePasswordInput parameters);

        /// <summary>
        /// 获取用户标签
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        [HttpGet(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<string> GetMark();

        /// <summary>
        /// 设置用户标签
        /// </summary>
        /// <param name="mark">用户标签</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        [HttpPost(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<bool> SetMark(string mark);

        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns>Task&lt;ListResult&lt;System.String&gt;&gt;.</returns>
        [HttpGet(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<ListResult<string>> GetDevices();

        /// <summary>
        /// 绑定设备
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        [ServiceRoute("{device}")]
        [HttpPost(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<bool> Binding(string device);

        /// <summary>
        /// 解绑设备
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        [ServiceRoute("{device}")]
        [HttpPost(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<bool> Unbundling(string device);

        /// <summary>
        /// 获取我的轨迹接口
        /// </summary>
        /// <returns>Task&lt;ListResult&lt;System.String&gt;&gt;.</returns>
        [HttpGet(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<ListResult<string>> GetTrails();

        /// <summary>
        /// 获取他的轨迹接口
        /// </summary>
        /// <param name="hisId">他的Id</param>
        /// <returns>Task&lt;ListResult&lt;System.String&gt;&gt;.</returns>
        [ServiceRoute("{hisId}")]
        [HttpGet(true)]
        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<ListResult<string>> GetHisTrails(string hisId);
    } 
}