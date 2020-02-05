namespace KissU.Util.Tools.Offices.Core
{
    /// <summary>
    /// 空单元格
    /// </summary>
    public class NullCell : Cell
    {
        /// <summary>
        /// 初始化空单元格
        /// </summary>
        public NullCell()
            : base("")
        {
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns><c>true</c> if this instance is null; otherwise, <c>false</c>.</returns>
        public override bool IsNull()
        {
            return true;
        }
    }
}