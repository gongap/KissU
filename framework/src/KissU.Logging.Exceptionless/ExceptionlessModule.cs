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
            ExceptionlessClient.Default.Configuration.ServerUrl = "http://localhost:8089";
            //ExceptionlessClient.Default.Configuration.ApiKey = "FgQufKpZSByltG0IJZ34QweEcigfiOoKin2uaVhY";
            ExceptionlessClient.Default.Startup("FgQufKpZSByltG0IJZ34QweEcigfiOoKin2uaVhY");
        }
    }
}