using KissU.Util;

namespace KissU.Modules.GreatWall.Domain.Models {
    /// <summary>
    /// 身份资源
    /// </summary>
    public partial class IdentityResource {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            InitName();
        }

        /// <summary>
        /// 初始化显示名称
        /// </summary>
        public void InitName() {
            if ( Name.IsEmpty() )
                Name = Uri;
        }
    }
}