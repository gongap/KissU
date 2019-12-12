using KissU.Core.Swagger.Swagger.Model;

namespace KissU.Core.Swagger
{
   public  class AppConfig
    {
        public static Info SwaggerOptions
        {
            get; internal set;
        }

        public static DocumentConfiguration SwaggerConfig
        {
            get; internal set;
        }
    }
}
