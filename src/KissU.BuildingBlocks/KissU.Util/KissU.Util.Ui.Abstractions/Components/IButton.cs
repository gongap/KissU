using KissU.Util.Ui.Abstractions.Operations;
using KissU.Util.Ui.Abstractions.Operations.Events;
using KissU.Util.Ui.Abstractions.Operations.Styles;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IButton : IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
