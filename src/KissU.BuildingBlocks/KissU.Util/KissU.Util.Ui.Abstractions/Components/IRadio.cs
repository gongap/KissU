using KissU.Util.Ui.Abstractions.Operations;
using KissU.Util.Ui.Abstractions.Operations.Bind;
using KissU.Util.Ui.Abstractions.Operations.Datas;
using KissU.Util.Ui.Abstractions.Operations.Events;
using KissU.Util.Ui.Abstractions.Operations.Forms;
using KissU.Util.Ui.Abstractions.Operations.Forms.Validations;
using KissU.Util.Ui.Abstractions.Operations.Layouts;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 单选框
    /// </summary>
    public interface IRadio : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition, IUrl, IDataSource, IItem, IColspan,
        IStandalone, IBindName {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        IRadio Enum<TEnum>();
    }
}
