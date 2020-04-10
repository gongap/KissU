using KissU.Surging.CPlatform;

namespace KissU.Surging.ProxyGenerator.Interceptors.Implementation.Metadatas
{
    public class ServiceLogIntercept : ServiceIntercept
    {
        protected override string MetadataId { get; set; } = "Log";


        #region 构造函数 
        /// <summary>
        ///  初始化一个新的<c>InterceptMethodAttribute</c>类型。
        /// </summary>
        public ServiceLogIntercept()
        {

        }
        #endregion

        #region 公共属性 
        #endregion

        public override void Apply(ServiceDescriptor descriptor)
        {
            descriptor.Intercept(MetadataId);
        }
    }
}
