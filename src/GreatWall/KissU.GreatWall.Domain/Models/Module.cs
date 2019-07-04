using Util.Helpers;

namespace KissU.GreatWall.Domain.Models {
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
    }
}