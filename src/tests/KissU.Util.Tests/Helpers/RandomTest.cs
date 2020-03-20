using System.Linq;
using KissU.Util.Helpers;
using Xunit;

namespace KissU.Util.Tests.Helpers
{
    /// <summary>
    /// 随机数操作测试
    /// </summary>
    public class RandomTest
    {
        /// <summary>
        /// 获取随机排序的集合
        /// </summary>
        [Fact]
        public void TestSort()
        {
            int[] input = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var list = Random.Sort(input);
            Assert.Equal(10, list.Distinct().Count());
            Assert.NotEqual("1,2,3,4,5,6,7,8,9,10", list.Join());
        }
    }
}