namespace PLP.Domain;

public class AuditedEntity<TKey> : IAuditedEntity<TKey>
{
    public TKey Id { get; set; }
    public DateTime? CreatedTime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedTime { get; set; }
    public string LastModifiedBy { get; set; }
}