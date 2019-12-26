// <copyright file="SecurityService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 安全服务
    /// </summary>
    public class SecurityService : ISecurityService
    {
        public async Task<SignInResult> SignInAsync(LoginRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task SignOutAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
