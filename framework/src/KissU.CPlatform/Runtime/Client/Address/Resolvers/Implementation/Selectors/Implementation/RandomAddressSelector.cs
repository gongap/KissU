﻿using System;
using System.Linq;
using System.Threading.Tasks;
using KissU.Address;

namespace KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation
{
    /// <summary>
    /// 一个随机的地址选择器。
    /// </summary>
    public class RandomAddressSelector : AddressSelectorBase
    {
        private readonly Func<int, int, int> _generate;
        private readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomAddressSelector" /> class.
        /// 初始化一个以Random生成随机数的随机地址选择器。
        /// </summary>
        public RandomAddressSelector()
        {
            _random = new Random();
            _generate = (min, max) => _random.Next(min, max);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomAddressSelector" /> class.
        /// 初始化一个自定义的随机地址选择器。
        /// </summary>
        /// <param name="generate">随机数生成委托，第一个参数为最小值，第二个参数为最大值（不可以超过该值）。</param>
        /// <exception cref="ArgumentNullException">generate</exception>
        public RandomAddressSelector(Func<int, int, int> generate)
        {
            if (generate == null)
            {
                throw new ArgumentNullException(nameof(generate));
            }

            _generate = generate;
        }

        /// <summary>
        /// 选择一个地址。
        /// </summary>
        /// <param name="context">地址选择上下文。</param>
        /// <returns>地址模型。</returns>
        protected override ValueTask<AddressModel> SelectAsync(AddressSelectContext context)
        {
            var address = context.Address.ToArray();
            var length = address.Length;

            var index = _generate(0, length);
            return new ValueTask<AddressModel>(address[index]);
        }
    }
}