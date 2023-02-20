namespace CollectionManager.Models.Domain
{
    public class Like
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IthemId { get; set; }
        public Ithem Ithem { get; set; }
        public string UserId { get; set; }
    }
}
