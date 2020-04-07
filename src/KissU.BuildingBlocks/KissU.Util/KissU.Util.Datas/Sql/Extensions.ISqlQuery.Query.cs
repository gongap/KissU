using System;
using System.Data;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Util.Ddd.Domain.Datas.Sql;
using Convert = KissU.Core.Helpers.Convert;

namespace KissU.Util.Datas.Sql
{
    /// <summary>
    /// Sql查询对象扩展 - 查询相关
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static async Task<string> ToStringAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return (await sqlQuery.ToScalarAsync(connection)).SafeString();
        }

        /// <summary>
        /// 获取整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToInt(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public static async Task<int> ToIntAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToInt(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取可空整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public static int? ToIntOrNull(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToIntOrNull(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取可空整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Nullable&lt;System.Int32&gt;&gt;.</returns>
        public static async Task<int?> ToIntOrNullAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToIntOrNull(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Single.</returns>
        public static float ToFloat(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToFloat(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Single&gt;.</returns>
        public static async Task<float> ToFloatAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToFloat(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取可空float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Nullable&lt;System.Single&gt;.</returns>
        public static float? ToFloatOrNull(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToFloatOrNull(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取可空float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Nullable&lt;System.Single&gt;&gt;.</returns>
        public static async Task<float?> ToFloatOrNullAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToFloatOrNull(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Double.</returns>
        public static double ToDouble(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDouble(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Double&gt;.</returns>
        public static async Task<double> ToDoubleAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDouble(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取可空double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Nullable&lt;System.Double&gt;.</returns>
        public static double? ToDoubleOrNull(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDoubleOrNull(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取可空double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Nullable&lt;System.Double&gt;&gt;.</returns>
        public static async Task<double?> ToDoubleOrNullAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDoubleOrNull(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Decimal.</returns>
        public static decimal ToDecimal(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDecimal(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Decimal&gt;.</returns>
        public static async Task<decimal> ToDecimalAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDecimal(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取可空decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Nullable&lt;System.Decimal&gt;.</returns>
        public static decimal? ToDecimalOrNull(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDecimalOrNull(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取可空decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Nullable&lt;System.Decimal&gt;&gt;.</returns>
        public static async Task<decimal?> ToDecimalOrNullAsync(this ISqlQuery sqlQuery,
            IDbConnection connection = null)
        {
            return Convert.ToDecimalOrNull(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ToBool(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToBool(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static async Task<bool> ToBoolAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToBool(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取可空布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool? ToBoolOrNull(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToBoolOrNull(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取可空布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Nullable&lt;System.Boolean&gt;&gt;.</returns>
        public static async Task<bool?> ToBoolOrNullAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToBoolOrNull(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDate(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDate(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;DateTime&gt;.</returns>
        public static async Task<DateTime> ToDateAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDate(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取可空日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static DateTime? ToDateOrNull(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDateOrNull(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取可空日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Nullable&lt;DateTime&gt;&gt;.</returns>
        public static async Task<DateTime?> ToDateOrNullAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToDateOrNull(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Guid.</returns>
        public static Guid ToGuid(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToGuid(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        public static async Task<Guid> ToGuidAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToGuid(await sqlQuery.ToScalarAsync(connection));
        }

        /// <summary>
        /// 获取可空Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>System.Nullable&lt;Guid&gt;.</returns>
        public static Guid? ToGuidOrNull(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToGuidOrNull(sqlQuery.ToScalar(connection));
        }

        /// <summary>
        /// 获取可空Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        /// <returns>Task&lt;System.Nullable&lt;Guid&gt;&gt;.</returns>
        public static async Task<Guid?> ToGuidOrNullAsync(this ISqlQuery sqlQuery, IDbConnection connection = null)
        {
            return Convert.ToGuidOrNull(await sqlQuery.ToScalarAsync(connection));
        }
    }
}