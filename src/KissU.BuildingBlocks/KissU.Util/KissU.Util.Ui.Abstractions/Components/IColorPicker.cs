using KissU.Util.Ui.Abstractions.Operations;
using KissU.Util.Ui.Abstractions.Operations.Bind;
using KissU.Util.Ui.Abstractions.Operations.Events;
using KissU.Util.Ui.Abstractions.Operations.Forms;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public interface IColorPicker : IComponent, IName, IDisabled, IModel, IOnChange,
        IStandalone, IBindName {
    }
}