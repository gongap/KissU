namespace KissU.Modules.AuditLogging.Domain
{
    public class EntityChangeWithUsername
    {
        public EntityChange EntityChange { get; set; }
        
        public string UserName { get; set; }
    }
}