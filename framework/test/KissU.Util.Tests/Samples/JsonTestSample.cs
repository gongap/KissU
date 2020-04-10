using KissU.Core.Helpers;

namespace KissU.Util.Tests.Samples
{
    /// <summary>
    /// A.
    /// </summary>
    public class A
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        public B B { get; set; }
    }

    /// <summary>
    /// B.
    /// </summary>
    public class B
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the c.
        /// </summary>
        public C C { get; set; }
    }

    /// <summary>
    /// C.
    /// </summary>
    public class C
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a.
        /// </summary>
        public A A { get; set; }
    }

    /// <summary>
    /// Json测试样例
    /// </summary>
    public class JsonTestSample
    {
        /// <summary>
        /// 名称,测试公共属性，且首字母大写
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 私有属性，应被忽略
        /// </summary>
        private string A { get; set; }

        /// <summary>
        /// 昵称，用来测试小写
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 测试null
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 测试整型，不添加引号
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 测试布尔型
        /// </summary>
        public bool isShow { get; set; }

        /// <summary>
        /// 创建客户
        /// </summary>
        /// <returns>JsonTestSample.</returns>
        public static JsonTestSample Create()
        {
            return new JsonTestSample
            {
                Name = "a",
                A = "1",
                nickname = "b",
                Value = null,
                Date = Convert.ToDate("2012-1-1").ToString(),
                Age = 1,
                isShow = true
            };
        }
    }
}