namespace KissU.Core.ApiGateWay
{
   public enum ServiceStatusCode
    {
        Success=200,
        RequestError =400,
        AuthorizationFailed=401,
        Http405Endpoint=405
    }
}
