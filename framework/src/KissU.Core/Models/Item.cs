using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace KissU.Models
{
    /// <summary>
    /// 列表项
    /// </summary>
    [DataContract]
    public class Item : IComparable<Item>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <param name="sortId">排序号</param>
        /// <param name="group">组</param>
        /// <param name="disabled">禁用</param>
        public Item(string text, object value, int? sortId = null, string group = null, bool? disabled = null)
        {
            Text = text;
            Value = value;
            SortId = sortId;
            Group = group;
            Disabled = disabled;
        }

        /// <summary>
        /// 文本
        /// </summary>
        [DataMember]
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; }

        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; }

        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        [JsonProperty("sortId", NullValueHandling = NullValueHandling.Ignore)]
        public int? SortId { get; }

        /// <summary>
        /// 组
        /// </summary>
        [DataMember]
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; }

        /// <summary>
        /// 禁用
        /// </summary>
        [DataMember]
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="other">其它列表项</param>
        /// <returns>System.Int32.</returns>
        public int CompareTo(Item other)
        {
            return string.Compare(Text, other.Text, StringComparison.CurrentCulture);
        }
    }
}