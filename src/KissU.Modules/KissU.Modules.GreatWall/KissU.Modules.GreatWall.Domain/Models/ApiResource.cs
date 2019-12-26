using KissU.Util;

namespace KissU.Modules.GreatWall.Domain.Models {
    /// <summary>
    /// Api资源
    /// </summary>
    public partial class ApiResource {
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
            if( Name.IsEmpty() )
                Name = Uri;
        }
    }
}