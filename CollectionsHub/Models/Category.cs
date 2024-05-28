namespace CollectionsHub.Models
{
    public class Category
    {
        public Guid CategoryId {  get; set; } = Guid.NewGuid();

        public required string Title { get; set; }

        public virtual ICollection<Collection> Collections { get; } = new List<Collection>();
    }
}
