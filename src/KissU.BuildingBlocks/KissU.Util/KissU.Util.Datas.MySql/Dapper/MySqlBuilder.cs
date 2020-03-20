using KissU.Core.Datas.Sql;
using KissU.Core.Datas.Sql.Builders;
using KissU.Core.Datas.Sql.Matedatas;
using KissU.Util.Datas.Sql;
using KissU.Util.Datas.Sql.Builders;
using KissU.Util.Datas.Sql.Builders.Core;

namespace KissU.Util.Datas.MySql.Dapper
{
    /// <summary>
    /// MySql Sql生成器
    /// </summary>
    public class MySqlBuilder : SqlBuilderBase
    {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="tableDatabase">表数据库</param>
        /// <param name="parameterManager">参数管理器</param>
        public MySqlBuilder(IEntityMatedata matedata = null, ITableDatabase tableDatabase = null,
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
            var sqlBuilder = new MySqlBuilder();
            sqlBuilder.Clone(this);
            return sqlBuilder;
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        /// <returns>IDialect.</returns>
        protected override IDialect GetDialect()
        {
            return new MySqlDialect();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        public override ISqlBuilder New()
        {
            return new MySqlBuilder(EntityMatedata, TableDatabase, ParameterManager);
        }

        /// <summary>
        /// 创建From子句
        /// </summary>
        /// <returns>IFromClause.</returns>
        protected override IFromClause CreateFromClause()
        {
            return new MySqlFromClause(this, GetDialect(), EntityResolver, AliasRegister, TableDatabase);
        }

        /// <summary>
        /// 创建Join子句
        /// </summary>
        /// <returns>IJoinClause.</returns>
        protected override IJoinClause CreateJoinClause()
        {
            return new MySqlJoinClause(this, GetDialect(), EntityResolver, AliasRegister, ParameterManager,
                TableDatabase);
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string CreateLimitSql()
        {
            return $"Limit {GetLimitParam()} OFFSET {GetOffsetParam()}";
        }

        /// <summary>
        /// 获取CTE关键字
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetCteKeyWord()
        {
            return "With Recursive";
        }
    }
}