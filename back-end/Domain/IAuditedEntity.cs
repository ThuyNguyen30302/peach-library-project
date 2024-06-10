namespace PLP.Domain;

public interface IAuditedEntity<TKey>  : IEntity<TKey>
{
    public DateTime? CreatedTime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedTime { get; set; }
    public string LastModifiedBy { get; set; }
}