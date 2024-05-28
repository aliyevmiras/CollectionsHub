namespace CollectionsHub.Models
{
    public class Collection
    {
        public Guid CollectionId { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Description { get; set; }
        
        // public Guid CategoryId { get; set; } 
        public Guid AuthorId { get; set; }
        public required virtual User Author { get; set; }
    }
}
