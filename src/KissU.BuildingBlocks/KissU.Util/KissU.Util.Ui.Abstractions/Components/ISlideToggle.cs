using KissU.Util.Ui.Abstractions.Operations;
using KissU.Util.Ui.Abstractions.Operations.Bind;
using KissU.Util.Ui.Abstractions.Operations.Events;
using KissU.Util.Ui.Abstractions.Operations.Forms;
using KissU.Util.Ui.Abstractions.Operations.Forms.Validations;
using KissU.Util.Ui.Abstractions.Operations.Layouts;
using KissU.Util.Ui.Abstractions.Operations.Styles;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 滑动开关
    /// </summary>
    public interface ISlideToggle : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition, IColor, IColspan,
        IStandalone, IBindName {
    }
}