﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using KissU.Core.Aspects.Base;
using KissU.Core.Helpers;

namespace KissU.Core.Validations.Aspects
{
    /// <summary>
    /// 验证拦截器
    /// </summary>
    public class ValidAttribute : ParameterInterceptorBase
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="next">The next.</param>
        public override async Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            Validate(context.Parameter);
            await next(context);
        }

        /// <summary>
        /// 验证
        /// </summary>
        private void Validate(Parameter parameter)
        {
            if (Reflection.IsGenericCollection(parameter.RawType))
            {
                ValidateCollection(parameter);
                return;
            }

            var validation = parameter.Value as IValidation;
            validation?.Validate();
        }

        /// <summary>
        /// 验证集合
        /// </summary>
        private void ValidateCollection(Parameter parameter)
        {
            if (!(parameter.Value is IEnumerable<IValidation> validations))
                return;
            foreach (var validation in validations)
                validation.Validate();
        }
    }
}