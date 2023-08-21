using Employment.Shared.Enum;


namespace Employment.Shared.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTimeOffset? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public EntityStatus Status { get; set; }
    }
}
