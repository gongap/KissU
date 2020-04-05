using System.Threading.Tasks;
using KissU.Core;
using KissU.Core.Datas.Queries;
using KissU.Core.Maps;
using KissU.Util.Applications;
using KissU.Util.Ddd.Datas.Queries;
using KissU.Util.Ddd.Datas.UnitOfWorks;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Util.Tests.Samples
{
    /// <summary>
    /// 增删改查服务样例
    /// </summary>
    public interface ICrudServiceSample : ICrudService<DtoSample, QueryParameterSample>
    {
    }

    /// <summary>
    /// 工作单元样例
    /// </summary>
    public class UnitOfWorkSample : IUnitOfWork
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Commit()
        {
            return 1;
        }

        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> CommitAsync()
        {
            return Task.FromResult(1);
        }
    }

    /// <summary>
    /// 增删改查服务样例
    /// </summary>
    public class CrudServiceSample : CrudServiceBase<EntitySample, DtoSample, QueryParameterSample>, ICrudServiceSample
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudServiceSample" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        public CrudServiceSample(IUnitOfWork unitOfWork, IRepositorySample repository) : base(unitOfWork, repository)
        {
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        /// <returns>EntitySample.</returns>
        protected override EntitySample ToEntity(DtoSample dto)
        {
            return dto.MapTo(new EntitySample(dto.Id.ToGuid()));
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>IQueryBase&lt;EntitySample&gt;.</returns>
        protected override IQueryBase<EntitySample> CreateQuery(QueryParameterSample parameter)
        {
            return new Query<EntitySample>(parameter);
        }
    }
}