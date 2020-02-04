using System;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors;

namespace KissU.Core.Consul.Internal.Cluster.Implementation.Selectors.Implementation
{
    /// <summary>
    /// ConsulAddressSelectorBase.
    /// Implements the <see cref="KissU.Core.Consul.Internal.Cluster.Implementation.Selectors.IConsulAddressSelector" />
    /// </summary>
    /// <seealso cref="KissU.Core.Consul.Internal.Cluster.Implementation.Selectors.IConsulAddressSelector" />
    public abstract class ConsulAddressSelectorBase : IConsulAddressSelector
    {
        #region Implementation of IAddressSelector

        /// <summary>
        /// 选择一个地址。
        /// </summary>
        /// <param name="context">地址选择上下文。</param>
        /// <returns>地址模型。</returns>
        async ValueTask<AddressModel> IAddressSelector.SelectAsync(AddressSelectContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Descriptor == null)
                throw new ArgumentNullException(nameof(context.Descriptor));
            if (context.Address == null)
                throw new ArgumentNullException(nameof(context.Address));

            //  var address = context.Address.ToArray();
            if (context.Address.Count() == 0)
                throw new ArgumentException("没有任何地址信息。", nameof(context.Address));

            if (context.Address.Count() == 1)
            {
                return context.Address.First();
            }

            var vt = SelectAsync(context);
            return vt.IsCompletedSuccessfully ? vt.Result : await vt;
        }

        #endregion Implementation of IAddressSelector

        /// <summary>
        /// 选择一个地址。
        /// </summary>
        /// <param name="context">地址选择上下文。</param>
        /// <returns>地址模型。</returns>
        protected abstract ValueTask<AddressModel> SelectAsync(AddressSelectContext context);
    }
}