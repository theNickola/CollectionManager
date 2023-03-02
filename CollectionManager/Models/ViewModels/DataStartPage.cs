using CollectionManager.Models.Domain;

namespace CollectionManager.Models.ViewModels
{
    public class DataStartPage
    {
        public IEnumerable<Ithem>? LastItems { get; set; }
        public IEnumerable<Collection>? BigCollections { set; get; }
        public IEnumerable<Collection>? AllCollections { set; get; } 
    }
}
