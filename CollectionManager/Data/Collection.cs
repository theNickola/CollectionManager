namespace CollectionManager.Data
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; } = "UserName";
        public string Description { get; set; } = "Some description ...";
        public int TopicId{ get; set; }
        public string? ImagePath { get; set; }
        public int UserId { get; set; }
        public string? NameDigitField1 { get; set; }
        public string? NameDigitField2 { get; set; }
        public string? NameDigitField3 { get; set; }
        public string? NameStringField1 { get; set; }
        public string? NameStringField2 { get; set; }
        public string? NameStringField3 { get; set; }
        public string? NameMarkdownField1 { get; set; }
        public string? NameMarkdownField2 { get; set; }
        public string? NameMarkdownField3 { get; set; }
        public string? NameDateField1 { get; set; }
        public string? NameDateField2 { get; set; }
        public string? NameDateField3 { get; set; }
        public string? NameBoolField1 { get; set; }
        public string? NameBoolField2 { get; set; }
        public string? NameBoolField3 { get; set; }
    }
}
