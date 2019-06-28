using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Util.Datas.Ef.Core;
using Util.Domains;

namespace KissU.Data.Repositories.Systems 
{
    /// <summary>
    /// Api资源仓储
    /// </summary>
    public class ApiRepository : RepositoryBase<Api>, IApiRepository 
	{
        /// <summary>
        /// 初始化Api资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) 
		{
        }

        public override void Update(Api api)
        {
            base.Update(api);
            foreach (var entity in api.ApiScopes)
            {

                UnitOfWork.Entry(entity).State = EntityState.Detached;
                var old = UnitOfWork.Set<ApiScope>().Find(entity.Id);
                var oldEntry = UnitOfWork.Entry(old);
                oldEntry.State = EntityState.Detached;
                oldEntry = UnitOfWork.Attach(old);
                oldEntry.CurrentValues.SetValues(entity);
            }
        }
    }
}