using System.Net;
using Newtonsoft.Json;

namespace KissU.Surging.CPlatform.Address
{
    /// <summary>
    /// 一个抽象的地址模型。
    /// </summary>
    public abstract class AddressModel
    {
        /// <summary>
        /// 处理器时间
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal ProcessorTime { get; set; }

        /// <summary>
        /// 创建终结点。
        /// </summary>
        /// <returns>终结点</returns>
        public abstract EndPoint CreateEndPoint();

        /// <summary>
        /// 重写后的标识。
        /// </summary>
        /// <returns>一个字符串。</returns>
        public abstract override string ToString();

        /// <summary>
        /// 确定指定对象是否等于当前对象。
        /// </summary>
        /// <param name="obj">要与当前对象进行比较的对象。</param>
        /// <returns>如果指定对象等于当前对象，则返回true；否则返回true。否则为假。</returns>
        public override bool Equals(object obj)
        {
            var model = obj as AddressModel;
            if (model == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return model.ToString() == ToString();
        }

        /// <summary>
        /// 用作默认哈希函数。
        /// </summary>
        /// <returns>当前对象的哈希码。</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(AddressModel model1, AddressModel model2)
        {
            return Equals(model1, model2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(AddressModel model1, AddressModel model2)
        {
            return !Equals(model1, model2);
        }
    }
}