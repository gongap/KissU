using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GreatWall.Service.Dtos.Requests;
using Util;

namespace GreatWall.Models {
    /// <summary>
    /// ��¼����
    /// </summary>
    public class LoginViewModel {
        /// <summary>
        /// �û���
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// ��ס����
        /// </summary>
        [Display( Name = "��ס����" )]
        public bool Remember { get; set; }
        /// <summary>
        /// �����ס����
        /// </summary>
        public bool AllowRemember { get; set; } = true;
        /// <summary>
        /// ���ص�ַ
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// ���ñ��ص�¼
        /// </summary>
        public bool EnableLocalLogin { get; set; } = true;
        /// <summary>
        /// �ⲿ��֤�ṩ���б�
        /// </summary>
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        /// <summary>
        /// �Ƿ��֧���ⲿ��¼
        /// </summary>
        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        /// <summary>
        /// �ⲿ��֤����
        /// </summary>
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
        /// <summary>
        /// ����ʾ���ⲿ��֤�ṩ���б�
        /// </summary>
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where( x => x.DisplayName.IsEmpty() == false );
        /// <summary>
        /// ��Ϣ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// ת��Ϊ��¼����
        /// </summary>
        public LoginRequest ToLoginRequest() {
            var result = new LoginRequest {
                UserName = UserName,
                Password = Password,
                Remember = Remember
            };
            return result;
        }
    }
}