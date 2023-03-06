using CollectionManager.Models.Domain;

namespace CollectionManager.Models.ViewModels
{
    public class IthemPage
    {
        public Ithem Ithem { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Like> Likes { get; set; }
    }
}
