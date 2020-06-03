namespace KissU.Randoms
{
    /// <summary>
    /// 随机数字生成器
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>System.Int32.</returns>
        int Generate(int min, int max);
    }
}