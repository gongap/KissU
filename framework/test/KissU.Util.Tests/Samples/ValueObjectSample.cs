using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KissU.Util.Ddd.Domain;

namespace KissU.Util.Tests.Samples
{
    /// <summary>
    /// 值对象测试样例
    /// </summary>
    public class ValueObjectSample : ValueObjectBase<ValueObjectSample>
    {
        /// <summary>
        /// 初始化值对象测试样例
        /// </summary>
        public ValueObjectSample()
        {
        }

        /// <summary>
        /// 初始化值对象测试样例
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="street">The street.</param>
        public ValueObjectSample(string city, string street)
            : this(city, street, null)
        {
        }

        /// <summary>
        /// 初始化值对象测试样例
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="street">The street.</param>
        /// <param name="sample">The sample.</param>
        public ValueObjectSample(string city, string street, AggregateRootSample sample)
            : this(city, street, sample, null)
        {
        }

        /// <summary>
        /// 初始化值对象测试样例
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="street">The street.</param>
        /// <param name="sample">The sample.</param>
        /// <param name="child">The child.</param>
        public ValueObjectSample(string city, string street, AggregateRootSample sample, ValueObjectSample child)
        {
            City = city;
            Street = street;
            AggregateRoot = sample;
            Child = child;
        }

        /// <summary>
        /// 城市
        /// </summary>
        [StringLength(100, ErrorMessage = "城市输入过长，不能超过100位")]
        public string City { get; }

        /// <summary>
        /// 街道
        /// </summary>
        [StringLength(200, ErrorMessage = "街道输入过长，不能超过200位")]
        public string Street { get; }

        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        [NotMapped]
        public AggregateRootSample AggregateRoot { get; }

        /// <summary>
        /// 子值对象测试样例
        /// </summary>
        [NotMapped]
        public ValueObjectSample Child { get; }
    }
}