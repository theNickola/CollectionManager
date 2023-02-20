using System.Security;

namespace CollectionManager.Data
{
    public class Topic
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; } = "Some description ...";
        public List<Collection> Collections { get; set; } = new();
    }
}
