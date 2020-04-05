using KissU.Util.Datas.Sql.Builders.Core;
using KissU.Util.Ddd.Datas.Sql;
using KissU.Util.Ddd.Datas.Sql.Builders;
using KissU.Util.Ddd.Datas.Sql.Matedatas;

namespace KissU.Util.Dapper.Oracle
{
    /// <summary>
    /// Oracle Sql生成器
    /// </summary>
    public class OracleBuilder : SqlBuilderBase
    {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="tableDatabase">表数据库</param>
        /// <param name="parameterManager">参数管理器</param>
        public OracleBuilder(IEntityMatedata matedata = null, ITableDatabase tableDatabase = null,
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
            var sqlBuilder = new OracleBuilder();
            sqlBuilder.Clone(this);
            return sqlBuilder;
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        /// <returns>IDialect.</returns>
        protected override IDialect GetDialect()
        {
            return new OracleDialect();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        public override ISqlBuilder New()
        {
            return new OracleBuilder(EntityMatedata, TableDatabase, ParameterManager);
        }

        /// <summary>
        /// 创建From子句
        /// </summary>
        /// <returns>IFromClause.</returns>
        protected override IFromClause CreateFromClause()
        {
            return new OracleFromClause(this, GetDialect(), EntityResolver, AliasRegister, TableDatabase);
        }

        /// <summary>
        /// 创建Join子句
        /// </summary>
        /// <returns>IJoinClause.</returns>
        protected override IJoinClause CreateJoinClause()
        {
            return new OracleJoinClause(this, GetDialect(), EntityResolver, AliasRegister, ParameterManager,
                TableDatabase);
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string CreateLimitSql()
        {
            return $"OFFSET {GetOffsetParam()} ROWS FETCH NEXT {GetLimitParam()} ROWS ONLY";
        }
    }
}