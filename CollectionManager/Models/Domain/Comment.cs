namespace CollectionManager.Models.Domain
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TextComment { get; set; }
        public DateTime DateCreation { get; } = DateTime.Now;
        public string IthemId { get; set; }
        public Ithem Ithem { get; set; }
        public string UserId { get; set; }
    }
}
