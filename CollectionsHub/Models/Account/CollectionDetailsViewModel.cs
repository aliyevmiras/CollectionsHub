namespace CollectionsHub.Models.Account
{
    public class CollectionDetailsViewModel
    {
        public Collection Collection { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
