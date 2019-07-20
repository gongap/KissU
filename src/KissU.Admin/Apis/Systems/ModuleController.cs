using System.Threading.Tasks;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Dtos.Requests;
using GreatWall.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Util.Ui.Controllers;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// 模块控制器
    /// </summary>
    public class ModuleController : TreeTableControllerBase<ModuleDto, ResourceQuery> {
        /// <summary>
        /// 初始化模块控制器
        /// </summary>
        /// <param name="service">模块服务</param>
        /// <param name="queryService">模块查询服务</param>
        public ModuleController( IModuleService service, IModuleQueryService queryService ) : base( queryService ) {
            ModuleService = service;
        }

        /// <summary>
        /// 模块服务
        /// </summary>
        public IModuleService ModuleService { get; }

        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync( [FromBody] CreateModuleRequest request ) {
            var id = await ModuleService.CreateAsync( request );
            return Success( id );
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync( [FromBody] ModuleDto request ) {
            await ModuleService.UpdateAsync( request );
            return Success();
        }
    }
}