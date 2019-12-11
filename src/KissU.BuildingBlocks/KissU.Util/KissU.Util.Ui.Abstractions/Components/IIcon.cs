using KissU.Util.Ui.Abstractions.Operations;
using KissU.Util.Ui.Abstractions.Operations.Effects;
using KissU.Util.Ui.Abstractions.Operations.Styles;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 图标
    /// </summary>
    public interface IIcon : IComponent, ISetIcon, IAttribute,IClass, IStyle, ISpin {
    }
}
