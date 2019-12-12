namespace KissU.Core.Swagger.Swagger.Model
{
    public class ApiKeyScheme : SecurityScheme
    {
        public string Name { get; set; }

        public string In { get; set; }

        public ApiKeyScheme()
        {
            Type = "apiKey";
        }
    }
}
