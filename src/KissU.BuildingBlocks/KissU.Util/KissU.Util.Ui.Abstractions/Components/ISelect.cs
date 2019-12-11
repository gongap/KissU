using KissU.Util.Ui.Abstractions.Operations.Datas;
using KissU.Util.Ui.Abstractions.Operations.Forms;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 下拉列表
    /// </summary>
    public interface ISelect : IFormControl, IUrl, IDataSource, IResetOption, IMultiple, IItem {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        ISelect Enum<TEnum>();
    }
}