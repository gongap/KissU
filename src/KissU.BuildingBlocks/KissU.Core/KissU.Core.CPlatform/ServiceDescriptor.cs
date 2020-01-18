using System;
using System.Collections.Generic;
using System.Linq;
using KissU.Core.CPlatform.Filters.Implementation;

namespace KissU.Core.CPlatform
{
    /// <summary>
    /// 服务描述符扩展方法。
    /// </summary>
    public static class ServiceDescriptorExtensions
    {
        /// <summary>
        /// 获取组名称。
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <returns>组名称。</returns>
        public static string GroupName(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata<string>("GroupName");
        }

        /// <summary>
        /// 设置组名称。
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <param name="groupName">组名称。</param>
        /// <returns>服务描述符。</returns>
        public static ServiceDescriptor GroupName(this ServiceDescriptor descriptor, string groupName)
        {
            descriptor.Metadatas["GroupName"] = groupName;
            return descriptor;
        }

        /// <summary>
        /// 设置是否等待执行。
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <param name="waitExecution">如果需要等待执行则为true，否则为false，默认为true。</param>
        /// <returns>服务描述符。</returns>
        public static ServiceDescriptor WaitExecution(this ServiceDescriptor descriptor, bool waitExecution)
        {
            descriptor.Metadatas["WaitExecution"] = waitExecution;
            return descriptor;
        }

        /// <summary>
        /// 获取负责人
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <param name="director">The director.</param>
        /// <returns>服务描述符。</returns>
        public static ServiceDescriptor Director(this ServiceDescriptor descriptor, string director)
        {
            descriptor.Metadatas["Director"] = director;
            return descriptor;
        }

        /// <summary>
        /// 设置是否启用授权
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <param name="enable">是否启用</param>
        /// <returns>服务描述符。</returns>
        public static ServiceDescriptor EnableAuthorization(this ServiceDescriptor descriptor, bool enable)
        {
            descriptor.Metadatas["EnableAuthorization"] = enable;
            return descriptor;
        }

        /// <summary>
        /// 获取是否启用授权
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <returns>服务描述符。</returns>
        public static bool EnableAuthorization(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata("EnableAuthorization", false);
        }

        /// <summary>
        /// HTTPs the method.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <returns>ServiceDescriptor.</returns>
        public static ServiceDescriptor HttpMethod(this ServiceDescriptor descriptor, string httpMethod)
        {
            descriptor.Metadatas["HttpMethod"] = httpMethod;
            return descriptor;
        }

        /// <summary>
        /// HTTPs the method.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        /// <returns>System.String.</returns>
        public static string HttpMethod(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata("httpMethod", "");
        }

        /// <summary>
        /// 设置是否禁用外网访问
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <param name="enable">是否禁用</param>
        /// <returns>服务描述符。</returns>
        public static ServiceDescriptor DisableNetwork(this ServiceDescriptor descriptor, bool enable)
        {
            descriptor.Metadatas["DisableNetwork"] = enable;
            return descriptor;
        }

        /// <summary>
        /// 获取是否禁用外网访问
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <returns>服务描述符。</returns>
        public static bool DisableNetwork(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata("DisableNetwork", false);
        }

        /// <summary>
        /// 获取授权类型
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <returns>服务描述符。</returns>
        public static string AuthType(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata("AuthType", "");
        }


        /// <summary>
        /// 设置授权类型
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <param name="authType">授权类型</param>
        /// <returns>服务描述符。</returns>
        public static ServiceDescriptor AuthType(this ServiceDescriptor descriptor, AuthorizationType authType)
        {
            descriptor.Metadatas["AuthType"] = authType.ToString();
            return descriptor;
        }

        /// <summary>
        /// 获取负责人
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <returns>System.String.</returns>
        public static string Director(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata<string>("Director");
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <param name="date">日期</param>
        /// <returns>服务描述符。</returns>
        public static ServiceDescriptor Date(this ServiceDescriptor descriptor, string date)
        {
            descriptor.Metadatas["Date"] = date;
            return descriptor;
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <returns>服务描述符。</returns>
        public static string Date(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata<string>("Date");
        }

        /// <summary>
        /// 获取释放等待执行的设置。
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        /// <returns>如果需要等待执行则为true，否则为false，默认为true。</returns>
        public static bool WaitExecution(this ServiceDescriptor descriptor)
        {
            return descriptor.GetMetadata("WaitExecution", true);
        }
    }

    /// <summary>
    /// 服务描述符。
    /// </summary>
    [Serializable]
    public class ServiceDescriptor
    {
        /// <summary>
        /// 初始化一个新的服务描述符。
        /// </summary>
        public ServiceDescriptor()
        {
            Metadatas = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 服务Id。
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// 访问的令牌
        /// </summary>
        /// <value>The token.</value>
        public string Token { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        /// <value>The route path.</value>
        public string RoutePath { get; set; }

        /// <summary>
        /// 元数据。
        /// </summary>
        /// <value>The metadatas.</value>
        public IDictionary<string, object> Metadatas { get; set; }

        /// <summary>
        /// 获取一个元数据。
        /// </summary>
        /// <typeparam name="T">元数据类型。</typeparam>
        /// <param name="name">元数据名称。</param>
        /// <param name="def">如果指定名称的元数据不存在则返回这个参数。</param>
        /// <returns>元数据值。</returns>
        public T GetMetadata<T>(string name, T def = default(T))
        {
            if (!Metadatas.ContainsKey(name))
                return def;

            return (T)Metadatas[name];
        }

        #region Equality members

        /// <summary>
        /// 确定指定对象是否等于当前对象.
        /// </summary>
        /// <param name="obj">与当前对象进行比较的对象.</param>
        /// <returns>如果指定对象等于当前对象，则返回true；否则返回true。否则为假。</returns>
        public override bool Equals(object obj)
        {
            var model = obj as ServiceDescriptor;
            if (model == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (model.Id != Id)
                return false;

            return model.Metadatas.Count == Metadatas.Count && model.Metadatas.All(metadata =>
                   {
                       object value;
                       if (!Metadatas.TryGetValue(metadata.Key, out value))
                           return false;

                       if (metadata.Value == null && value == null)
                           return true;
                       if (metadata.Value == null || value == null)
                           return false;

                       return metadata.Value.Equals(value);
                   });
        }

        /// <summary>
        /// 用作默认哈希函数。
        /// </summary>
        /// <returns>当前对象的哈希码.</returns>
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
        public static bool operator ==(ServiceDescriptor model1, ServiceDescriptor model2)
        {
            return Equals(model1, model2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ServiceDescriptor model1, ServiceDescriptor model2)
        {
            return !Equals(model1, model2);
        }

        #endregion Equality members
    }
}