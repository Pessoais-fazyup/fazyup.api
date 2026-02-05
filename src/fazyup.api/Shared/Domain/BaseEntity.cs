namespace fazyup.api.Shared.Domain
{
    public abstract class BaseEntity<TEntity>
    {
        public TEntity Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
