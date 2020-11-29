namespace KissU.Modules.Identity.Domain
{
    public class IdentityRoleNameChangedEvent
    {
        public IdentityRole IdentityRole { get; set; }
        public string OldName { get; set; }
    }
}
