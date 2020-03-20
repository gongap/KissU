using KissU.Core;
using QRCoder;

namespace KissU.Util.Tools.QrCode.QrCoder
{
    /// <summary>
    /// QRCoder二维码服务
    /// </summary>
    public class QrCoderService : IQrCodeService
    {
        /// <summary>
        /// 容错级别
        /// </summary>
        private QRCodeGenerator.ECCLevel _level;

        /// <summary>
        /// 二维码尺寸
        /// </summary>
        private int _size;

        /// <summary>
        /// 初始化QRCoder组件二维码服务
        /// </summary>
        public QrCoderService()
        {
            _size = 10;
            _level = QRCodeGenerator.ECCLevel.L;
        }

        /// <summary>
        /// 设置二维码尺寸
        /// </summary>
        /// <param name="size">二维码尺寸</param>
        /// <returns>IQrCodeService.</returns>
        public IQrCodeService Size(QrSize size)
        {
            return Size(size.Value());
        }

        /// <summary>
        /// 设置二维码尺寸
        /// </summary>
        /// <param name="size">二维码尺寸</param>
        /// <returns>IQrCodeService.</returns>
        public IQrCodeService Size(int size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// 容错处理
        /// </summary>
        /// <param name="level">容错级别</param>
        /// <returns>IQrCodeService.</returns>
        public IQrCodeService Correction(ErrorCorrectionLevel level)
        {
            switch (level)
            {
                case ErrorCorrectionLevel.L:
                    _level = QRCodeGenerator.ECCLevel.L;
                    break;
                case ErrorCorrectionLevel.M:
                    _level = QRCodeGenerator.ECCLevel.M;
                    break;
                case ErrorCorrectionLevel.Q:
                    _level = QRCodeGenerator.ECCLevel.Q;
                    break;
                case ErrorCorrectionLevel.H:
                    _level = QRCodeGenerator.ECCLevel.H;
                    break;
            }

            return this;
        }

        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>System.Byte[].</returns>
        public byte[] CreateQrCode(string content)
        {
            var generator = new QRCodeGenerator();
            var data = generator.CreateQrCode(content, _level);
            var qrCode = new BitmapByteQRCode(data);
            return qrCode.GetGraphic(_size);
        }
    }
}