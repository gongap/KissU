using System;
using System.Text;
using KissU.Core.Helpers;

namespace KissU.Core.Events
{
    /// <summary>
    /// 事件
    /// </summary>
    public class Event : IEvent
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        public Event()
        {
            Id = Helpers.Id.Guid();
            Time = DateTime.Now;
        }

        /// <summary>
        /// 事件标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 事件时间
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"事件标识: {Id}");
            result.AppendLine($"事件时间:{Time.ToMillisecondString()}");
            result.Append($"事件数据：{Json.ToJson(this)}");
            return result.ToString();
        }
    }
}