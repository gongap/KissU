namespace KissU.Core.Stage.Configurations
{
   public class AccessPolicyOption
    {
        public string[] Origins { get; set; }

        public bool AllowAnyHeader { get; set; }

        public bool AllowAnyMethod { get; set; }

        public bool AllowAnyOrigin { get; set; }

        public bool AllowCredentials { get; set; }
    }
}
