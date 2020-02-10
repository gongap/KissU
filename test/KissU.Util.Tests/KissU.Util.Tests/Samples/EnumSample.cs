using System.ComponentModel;

namespace KissU.Util.Tests.Samples
{
    /// <summary>
    /// 枚举测试样例
    /// </summary>
    public enum EnumSample
    {
        /// <summary>
        /// a
        /// </summary>
        A = 1,

        /// <summary>
        /// The b
        /// </summary>
        [Description("B2")] B = 2,

        /// <summary>
        /// The c
        /// </summary>
        [Description("C3")] C = 3,

        /// <summary>
        /// The d
        /// </summary>
        [Description("D4")] D = 4,

        /// <summary>
        /// The e
        /// </summary>
        [Description("E5")] E = 5
    }
}