using KissU.Util.Ui.Abstractions.Operations;
using KissU.Util.Ui.Abstractions.Operations.Events;
using KissU.Util.Ui.Abstractions.Operations.Navigation;
using KissU.Util.Ui.Abstractions.Operations.Styles;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 链接
    /// </summary>
    public interface IAnchor : IComponent, ILink, IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
