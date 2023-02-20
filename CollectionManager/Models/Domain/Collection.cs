using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Identity;

namespace CollectionManager.Models.Domain
{
    public class Collection
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "UserName";
        public string Description { get; set; } = "Some description ...";
        public string? ImagePath { get; set; }
        public DateTime DateCreation { get; } = DateTime.Now;
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
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Ithem> Ithems { get; set; } = new();
    }
}
