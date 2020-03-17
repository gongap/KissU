using System;
using System.Runtime.InteropServices;

namespace KissU.Surging.System.Module.Attributes
{
    /// <summary>
    /// AssemblyModuleTypeAttribute. This class cannot be inherited.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Assembly)]
    [ComVisible(true)]
    public sealed class AssemblyModuleTypeAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// 获取模块类型
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/8</para>
        /// </remarks>
        public ModuleType Type { get; private set; }

        /// <summary>
        /// Gets the serial number.
        /// </summary>
        public int SerialNumber { get; private set; }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化一个新的 <see cref="AssemblyModuleTypeAttribute" /> 类实例。
        /// </summary>
        /// <param name="type">模块类型。</param>
        /// <param name="serialNumber">序号</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/8</para>
        /// </remarks>
        public AssemblyModuleTypeAttribute(ModuleType type, int serialNumber)
        {
            Type = type;
            SerialNumber = serialNumber;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyModuleTypeAttribute" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public AssemblyModuleTypeAttribute(ModuleType type)
        {
            Type = type;
        }

        #endregion
    }
}