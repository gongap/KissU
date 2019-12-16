using System;

namespace KissU.Util.Datas.Sql
{
    /// <summary>
    /// 忽略生成列
    /// </summary>
    [AttributeUsage( AttributeTargets.Property )]
    public class IgnoreAttribute : Attribute
    {
    }
}
