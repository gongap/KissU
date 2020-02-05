using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace KissU.Util.Tools.Offices.Npoi
{
    /// <summary>
    /// Npoi Excel2003操作
    /// </summary>
    public class Excel2003 : ExcelBase
    {
        /// <summary>
        /// 创建工作薄
        /// </summary>
        /// <returns>IWorkbook.</returns>
        protected override IWorkbook GetWorkbook()
        {
            return new HSSFWorkbook();
        }
    }
}