namespace BackEnd.Domain.Base.Entities;

public class Entity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; }
}