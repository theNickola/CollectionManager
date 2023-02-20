namespace CollectionManager.Data
{
    public class Ithem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime DateCreation { get; } = DateTime.Now;
        public string? DigitField1 { get; set; }
        public string? DigitField2 { get; set; }
        public string? DigitField3 { get; set; }
        public string? StringField1 { get; set; }
        public string? StringField2 { get; set; }
        public string? StringField3 { get; set; }
        public string? MarkdownField1 { get; set; }
        public string? MarkdownField2 { get; set; }
        public string? MarkdownField3 { get; set; }
        public string? DateField1 { get; set; }
        public string? DateField2 { get; set; }
        public string? DateField3 { get; set; }
        public string? BoolField1 { get; set; }
        public string? BoolField2 { get; set; }
        public string? BoolField3 { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; } = new();
        public List<Like> Likes { get; set; } = new();
        public string CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}
