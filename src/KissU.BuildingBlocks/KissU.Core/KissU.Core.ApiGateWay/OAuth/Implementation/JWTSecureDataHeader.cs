namespace KissU.Core.ApiGateWay.OAuth.Implementation
{
   public class JWTSecureDataHeader
    {
        public JWTSecureDataType Type { get; set; }

        public EncryptMode EncryptMode { get; set; }

        public string TimeStamp { get; set; }
    }
}
