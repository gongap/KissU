using KissU.Util.Ui.Abstractions.Operations;
using KissU.Util.Ui.Abstractions.Operations.Bind;
using KissU.Util.Ui.Abstractions.Operations.Events;
using KissU.Util.Ui.Abstractions.Operations.Forms;
using KissU.Util.Ui.Abstractions.Operations.Forms.Validations;
using KissU.Util.Ui.Abstractions.Operations.Layouts;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 表单控件
    /// </summary>
    public interface IFormControl : IComponent,IName,IDisabled, IPlaceholder, IHint, IPrefix, ISuffix, IModel, 
        IRequired, IOnChange, IOnFocus, IOnBlur, IOnKeyup, IOnKeydown, IColspan, IStandalone,
        IBindName {
    }
}