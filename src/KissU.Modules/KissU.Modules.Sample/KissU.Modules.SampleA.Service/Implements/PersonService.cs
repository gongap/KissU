using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KissU.Core.Common;
using KissU.Core.CPlatform.EventBus.Events;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.KestrelHttpServer.Abstractions;
using KissU.Core.KestrelHttpServer.Internal;
using KissU.Core.ProxyGenerator;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Repositories;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// PersonService.
    /// Implements the <see cref="KissU.Core.ProxyGenerator.ProxyServiceBase" />
    /// Implements the <see cref="KissU.Modules.SampleA.Service.Contracts.IUserService" />
    /// </summary>
    /// <seealso cref="KissU.Core.ProxyGenerator.ProxyServiceBase" />
    /// <seealso cref="KissU.Modules.SampleA.Service.Contracts.IUserService" />
    [ModuleName("Person")]
    public class PersonService : ProxyServiceBase, IUserService
    {
        #region Implementation of IUserService

        private readonly UserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public PersonService(UserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public Task<string> GetUserName(int id)
        {
            return GetService<IUserService>("User").GetUserName(id);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public Task<bool> Exists(int id)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// 根据用户名获取用户ID
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> GetUserId(string userName)
        {
            return Task.FromResult(1);
        }

        /// <summary>
        /// 获取用户最后次sign时间
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>Task&lt;DateTime&gt;.</returns>
        public Task<DateTime> GetUserLastSignInTime(int id)
        {
            return Task.FromResult(DateTime.Now);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>Task&lt;UserModel&gt;.</returns>
        public Task<UserModel> GetUser(UserModel user)
        {
            return Task.FromResult(new UserModel
            {
                Name = "fanly",
                Age = 18
            });
        }

        /// <summary>
        /// 测试List参数调用
        /// </summary>
        /// <param name="users">用户列表</param>
        /// <returns>返回是否成功</returns>
        public Task<bool> Get(List<UserModel> users)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="model">用户模型</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public Task<bool> Update(int id, UserModel model)
        {
            return Task.FromResult(true);
        }


        /// <summary>
        /// 测序guid
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;UserModel&gt;.</returns>
        public Task<UserModel> GetUserById(Guid id)
        {
            return Task.FromResult(new UserModel());
        }

        /// <summary>
        /// 测试无参数调用
        /// </summary>
        /// <returns>返回是否成功</returns>
        public Task<bool> GetDictionary()
        {
            return Task.FromResult(true);
        }


        /// <summary>
        /// Tries this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task Try()
        {
            Console.WriteLine("start");
            await Task.Delay(5000);
            Console.WriteLine("end");
        }

        /// <summary>
        /// 测试异常
        /// </summary>
        /// <returns>Task.</returns>
        /// <exception cref="System.Exception">用户Id非法！</exception>
        public Task TryThrowException()
        {
            throw new Exception("用户Id非法！");
        }

        /// <summary>
        /// publish through event bus as an asynchronous operation.
        /// </summary>
        /// <param name="evt">The evt.</param>
        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// 用戶授权
        /// </summary>
        /// <param name="requestData">请求参数</param>
        /// <returns>用户模型</returns>
        public Task<UserModel> Authentication(AuthenticationRequestData requestData)
        {
            if (requestData.UserName == "admin" && requestData.Password == "admin")
            {
                return Task.FromResult(new UserModel());
            }

            return Task.FromResult<UserModel>(null);
        }

        /// <summary>
        /// 报错用户
        /// </summary>
        /// <param name="requestData">请求参数</param>
        /// <returns>Task&lt;IdentityUser&gt;.</returns>
        public Task<IdentityUser> Save(IdentityUser requestData)
        {
            return Task.FromResult(requestData);
        }

        /// <summary>
        /// 测试无参调用，返回泛型结果
        /// </summary>
        /// <returns>Task&lt;ApiResult&lt;UserModel&gt;&gt;.</returns>
        public Task<ApiResult<UserModel>> GetApiResult()
        {
            return Task.FromResult(new ApiResult<UserModel> {Value = new UserModel {Name = "fanly"}, StatusCode = 200});
        }

        /// <summary>
        /// 测试参数list参数
        /// </summary>
        /// <param name="idList">list 类型参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public Task<string> GetUser(List<int> idList)
        {
            return Task.FromResult("type is List<int>");
        }

        /// <summary>
        /// 测试上传文件
        /// </summary>
        /// <param name="form">HttpFormCollection 类型参数</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> UploadFile(HttpFormCollection form)
        {
            var files = form.Files;
            foreach (var file in files)
            {
                using (var stream =
                    new FileStream(Path.Combine(AppContext.BaseDirectory, file.FileName), FileMode.Create))
                {
                    await stream.WriteAsync(file.File, 0, (int) file.Length);
                }
            }

            return true;
        }

        /// <summary>
        /// 测试下载文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="contentType">Content-Type</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public async Task<IActionResult> DownFile(string fileName, string contentType)
        {
            var uploadPath = Path.Combine("C:", fileName);
            if (File.Exists(uploadPath))
            {
                using (var stream = new FileStream(uploadPath, FileMode.Open))
                {
                    var bytes = new byte[stream.Length];
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    return new FileContentResult(bytes, contentType, fileName);
                }
            }

            throw new FileNotFoundException(fileName);
        }

        /// <summary>
        /// Sets the sex.
        /// </summary>
        /// <param name="sex">The sex.</param>
        /// <returns>Task&lt;Sex&gt;.</returns>
        public async Task<Sex> SetSex(Sex sex)
        {
            return await Task.FromResult(sex);
        }

        /// <summary>
        /// Gets all things.
        /// </summary>
        /// <returns>Task&lt;Dictionary&lt;System.String, System.Object&gt;&gt;.</returns>
        public async Task<Dictionary<string, object>> GetAllThings()
        {
            return await Task.FromResult(new Dictionary<string, object> {{"aaa", 12}});
        }

        #endregion Implementation of IUserService
    }
}