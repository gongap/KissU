using KissU.Core.Helpers;

namespace KissU.Core.Files
{
    /// <summary>
    /// 文件大小
    /// </summary>
    public struct FileSize
    {
        /// <summary>
        /// 初始化文件大小
        /// </summary>
        /// <param name="size">文件大小</param>
        /// <param name="unit">文件大小单位</param>
        public FileSize(long size, FileSizeUnit unit = FileSizeUnit.Byte)
        {
            Size = GetSize(size, unit);
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        private static long GetSize(long size, FileSizeUnit unit)
        {
            switch (unit)
            {
                case FileSizeUnit.K:
                    return size * 1024;
                case FileSizeUnit.M:
                    return size * 1024 * 1024;
                case FileSizeUnit.G:
                    return size * 1024 * 1024 * 1024;
                default:
                    return size;
            }
        }

        /// <summary>
        /// 文件字节长度
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// 获取文件大小，单位：字节
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetSize()
        {
            return (int) Size;
        }

        /// <summary>
        /// 获取文件大小，单位：K
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetSizeByK()
        {
            return Convert.ToDouble(Size / 1024.0, 2);
        }

        /// <summary>
        /// 获取文件大小，单位：M
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetSizeByM()
        {
            return Convert.ToDouble(Size / 1024.0 / 1024.0, 2);
        }

        /// <summary>
        /// 获取文件大小，单位：G
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetSizeByG()
        {
            return Convert.ToDouble(Size / 1024.0 / 1024.0 / 1024.0, 2);
        }

        /// <summary>
        /// 输出描述
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            if (Size >= 1024 * 1024 * 1024)
                return $"{GetSizeByG()} {FileSizeUnit.G.Description()}";
            if (Size >= 1024 * 1024)
                return $"{GetSizeByM()} {FileSizeUnit.M.Description()}";
            if (Size >= 1024)
                return $"{GetSizeByK()} {FileSizeUnit.K.Description()}";
            return $"{Size} {FileSizeUnit.Byte.Description()}";
        }
    }
}