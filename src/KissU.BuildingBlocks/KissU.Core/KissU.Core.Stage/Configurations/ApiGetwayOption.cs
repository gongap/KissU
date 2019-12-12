namespace KissU.Core.Stage.Configurations
{
   public class ApiGetwayOption
    {
        public  string CacheMode{get;set; }

        public string AuthorizationServiceKey { get; set; }

        public string AuthorizationRoutePath { get; set; }

        public int AccessTokenExpireTimeSpan { get; set; } = 30;

        public string TokenEndpointPath{ get; set; }
    }
}
