namespace KissU.Modules.PermissionManagement.Application.Contracts
{
    public class UpdatePermissionDto
    {
        public string Name { get; set; }

        public bool IsGranted { get; set; }
    }
}