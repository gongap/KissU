using System.ComponentModel.DataAnnotations;

namespace KissU.Identity.Models.AccountViewModels
{
    /// <summary>
    /// �ⲿ��¼��ͼģ��
    /// </summary>
    public class ExternalLoginViewModel
    {
        /// <summary>
        /// �����ʼ�
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
