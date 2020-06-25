namespace KissU.AuthServer.Host.Areas.Account.Controllers.Models
{
    public class LoginResult
    {
        public LoginResult(LoginResultType result)
        {
            Result = result;
        }

        public LoginResultType Result { get; }

        public string Description => Result.ToString();
    }
}