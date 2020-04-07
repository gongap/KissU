using System;

namespace KissU.Util.Ddd.Data.Sql
{
    /// <summary>
    /// 忽略生成列
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}