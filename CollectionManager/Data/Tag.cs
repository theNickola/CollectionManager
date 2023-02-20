namespace CollectionManager.Data
{
    public class Tag
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<Ithem> Ithems { get; set; } = new();
    }
}
