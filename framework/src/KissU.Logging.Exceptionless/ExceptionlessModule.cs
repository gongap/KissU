using Exceptionless;
using KissU.Modularity;

namespace KissU.Logging.Exceptionless
{
    /// <summary>
    /// ExceptionlessModule.
    /// </summary>
    public class ExceptionlessModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            ExceptionlessClient.Default.Startup("K5eb9azwszauu9094Nuii0hXhWcpxoSqr3CqVjer");
            //ExceptionlessClient.Default.Configuration.ApiKey = Configuration.GetSection("K5eb9azwszauu9094Nuii0hXhWcpxoSqr3CqVjer").Value;
            //ExceptionlessClient.Default.Configuration.ServerUrl = Configuration.GetSection("http://localhost:8001").Value;
            //ExceptionlessClient.Default.Configuration.ApiKey = Configuration.GetSection("Exceptionless:ApiKey").Value;
            //ExceptionlessClient.Default.Configuration.ServerUrl = Configuration.GetSection("Exceptionless:ServerUrl").Value;
            //app.UseExceptionless();
            //"Exceptionless": {
            //    "ApiKey": "aW6nxAsLNE5JcFthRbjbh5Ot2iFk4MgrcZtC35Ut",
            //    "ServerUrl": "http://localhost:50000"
            //}
        }
    }
}