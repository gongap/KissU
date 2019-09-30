using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Surging.Core.ApiGateWay;

namespace KissU.ApiGateway
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                return;
            }
            var result =  ServiceResult<object>.Create(false,errorMessage: context.Exception.Message);
            result.StatusCode = 400;
            context.Result =new JsonResult(result);
        }
    }
}

