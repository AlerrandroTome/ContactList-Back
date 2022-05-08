namespace ContactList.Core
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime InclusionDate { get; set; }
        public DateTime? LastUpdateDate { get; set; } = null;
    }
}
