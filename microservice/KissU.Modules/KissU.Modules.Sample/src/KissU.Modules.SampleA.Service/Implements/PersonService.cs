﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using KissU.Dependency;
using KissU.EventBus.Events;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Repositories;
using KissU.Kestrel.Abstractions;
using KissU.Kestrel.Http.Abstractions;
using KissU.Kestrel.Http.Internal;
using KissU.Models;
using KissU.ServiceProxy;

namespace KissU.Modules.SampleA.Service.Implements
{
    [ModuleName("Person")]
    public class PersonService : ProxyServiceBase, IUserService
    {
        #region Implementation of IUserService
        private readonly UserRepository _repository;
        public PersonService(UserRepository repository)
        {
            _repository = repository;
        }

        public Task<string> GetUserName(int id)
        {
            return GetService<IUserService>("User").GetUserName(id);
        }

        public Task<bool> Exists(int id)
        {
            return Task.FromResult(true);
        }

        public Task<int> GetUserId(string userName)
        {
            return Task.FromResult(1);
        }

        public Task<DateTime> GetUserLastSignInTime(int id)
        {
            return Task.FromResult(DateTime.Now);
        }

        public Task<UserModel> GetUser(UserModel user)
        {
            return Task.FromResult(new UserModel
            {
                Name = "fanly",
                Age = 18
            });
        }

        public Task<bool> Get(List<UserModel> users)
        {
            return Task.FromResult(true);
        }

        public Task<bool> Update(int id, UserModel model)
        {
            return Task.FromResult(true);
        }


        public Task<UserModel> GetUserById(Guid id)
        {
            return Task.FromResult(new UserModel
            {

            });
        }

        public Task<bool> GetDictionary()
        {
            return Task.FromResult(true);
        }


        public async Task Try()
        {
            Console.WriteLine("start");
            await Task.Delay(5000);
            Console.WriteLine("end");
        }

        public Task TryThrowException()
        {
            throw new Exception("用户Id非法！");
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            await Task.CompletedTask;
        }

        public Task<UserModel> Authentication(AuthenticationRequestData requestData)
        {
            if (requestData.UserName == "admin" && requestData.Password == "admin")
            {
                return Task.FromResult(new UserModel());
            }
            return Task.FromResult<UserModel>(null);
        }

        public Task<IdentityUser> Save(IdentityUser requestData)
        {
            return Task.FromResult(requestData);
        }

        public Task<ApiResult<UserModel>> GetApiResult()
        {
            return Task.FromResult(new ApiResult<UserModel>() { Data = new UserModel { Name = "fanly" }, Code = StateCode.Ok });
        }

        public Task<string> GetUser(List<int> idList)
        {
            return Task.FromResult("type is List<int>");
        }

        public async Task<bool> UploadFile(HttpFormCollection form1)
        {
            var files = form1.Files;
            foreach (var file in files)
            {
                using (var stream = new FileStream(Path.Combine(AppContext.BaseDirectory, file.FileName), FileMode.Create))
                {
                    await stream.WriteAsync(file.File, 0, (int)file.Length);
                }
            }
            return true;
        }

        public async Task<IActionResult> DownFile(string fileName, string contentType)
        {
            string uploadPath = Path.Combine("C:", fileName);
            if (File.Exists(uploadPath))
            {
                using (var stream = new FileStream(uploadPath, FileMode.Open))
                {

                    var bytes = new byte[stream.Length];
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    return new FileContentResult(bytes, contentType, fileName);
                }
            }
            else
            {
                throw new FileNotFoundException(fileName);
            }

        }

        public async Task<Sex> SetSex(Sex sex)
        {
            return await Task.FromResult(sex);
        }

        public async Task<Dictionary<string, object>> GetAllThings()
        {
            return await Task.FromResult(new Dictionary<string, object> { { "aaa", 12 } });
        }

        public Task<bool> RemoveUser(UserModel user)
        {
            return Task.FromResult(true);
        }

        #endregion Implementation of IUserService
    }
}