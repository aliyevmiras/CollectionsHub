using Microsoft.Identity.Client;

namespace CollectionsHub.Models
{
    public class Item
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public Guid CollectionId {  get; set; }

        public required virtual Collection Collection { get; set; }

    }
}
