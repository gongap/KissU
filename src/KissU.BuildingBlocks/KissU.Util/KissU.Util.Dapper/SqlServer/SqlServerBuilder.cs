using KissU.Core.Datas.Sql;
using KissU.Core.Datas.Sql.Builders;
using KissU.Core.Datas.Sql.Matedatas;
using KissU.Util.Datas.Sql.Builders.Core;

namespace KissU.Util.Dapper.SqlServer
{
    /// <summary>
    /// Sql Server Sql生成器
    /// </summary>
    public class SqlServerBuilder : SqlBuilderBase
    {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="tableDatabase">表数据库</param>
        /// <param name="parameterManager">参数管理器</param>
        public SqlServerBuilder(IEntityMatedata matedata = null, ITableDatabase tableDatabase = null,
            IParameterManager parameterManager = null)
            : base(matedata, tableDatabase, parameterManager)
        {
        }

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        public override ISqlBuilder Clone()
        {
            var sqlBuilder = new SqlServerBuilder();
            sqlBuilder.Clone(this);
            return sqlBuilder;
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        /// <returns>IDialect.</returns>
        protected override IDialect GetDialect()
        {
            return new SqlServerDialect();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        public override ISqlBuilder New()
        {
            return new SqlServerBuilder(EntityMatedata, TableDatabase, ParameterManager);
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string CreateLimitSql()
        {
            return $"Offset {GetOffsetParam()} Rows Fetch Next {GetLimitParam()} Rows Only";
        }
    }
}