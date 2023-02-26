using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.Models.Domain
{
    public class Collection
    {
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = "UserName";
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; } = "Some description ...";
        public string? ImagePath { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [Column(TypeName = "varchar(50)")]
        public string? NameDigitField1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameDigitField2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameDigitField3 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameStringField1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameStringField2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameStringField3 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameMarkdownField1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameMarkdownField2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameMarkdownField3 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameDateField1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameDateField2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameDateField3 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameBoolField1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameBoolField2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NameBoolField3 { get; set; }
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Ithem> Ithems { get; set; } = new();
    }
}
