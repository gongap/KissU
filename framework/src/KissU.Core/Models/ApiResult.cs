using System.Runtime.Serialization;

namespace KissU.Models
{
    /// <summary>
    /// 返回结果.
    /// </summary>
    [DataContract]
    public class ApiResult : ApiResult<dynamic>
    {
    }

    /// <summary>
    /// 返回结果.
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    [DataContract]
    public class ApiResult<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [DataMember]
        public StateCode Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }
}