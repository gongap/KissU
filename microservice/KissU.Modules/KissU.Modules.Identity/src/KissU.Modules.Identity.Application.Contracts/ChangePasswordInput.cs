namespace KissU.Modules.Identity.Application.Contracts
{
    public class ChangePasswordInput
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
