using KissU.Util.Ui.Abstractions.Operations.Forms;
using KissU.Util.Ui.Abstractions.Operations.Forms.Validations;

namespace KissU.Util.Ui.Abstractions.Components {
    /// <summary>
    /// 文本框
    /// </summary>
    public interface ITextBox : IFormControl, IReadOnly, IMinLength, IMaxLength,IMin,IMax, IRegex {
    }
}
