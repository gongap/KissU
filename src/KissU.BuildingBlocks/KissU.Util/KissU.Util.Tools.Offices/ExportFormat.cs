using System.ComponentModel;

namespace KissU.Util.Tools.Offices {
    /// <summary>
    /// 导出格式
    /// </summary>
    public enum ExportFormat {
        /// <summary>
        /// Excel 2003
        /// </summary>
        [Description("Excel2003")]
        Xls,
        /// <summary>
        /// Excel 2007+
        /// </summary>
        [Description( "Excel2007+" )]
        Xlsx
    }
}
