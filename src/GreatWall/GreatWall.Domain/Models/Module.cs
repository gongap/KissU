using Util;
using Util.Helpers;

namespace GreatWall.Domain.Models {
    /// <summary>
    /// 模块
    /// </summary>
    public partial class Module {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            InitPinYin();
        }

        /// <summary>
        /// 初始化拼音简码
        /// </summary>
        public void InitPinYin() {
            PinYin = String.PinYin( Name );
        }

        /// <summary>
        /// 是否外部地址
        /// </summary>
        public bool IsExternalUrl() {
            if ( Url.IsEmpty() )
                return false;
            if ( Url.StartsWith( "http" ) )
                return true;
            return false;
        }
    }
}