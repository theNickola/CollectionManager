using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.Models.Domain
{
    public class Ithem
    {
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public double? DigitField1 { get; set; }
        public double? DigitField2 { get; set; }
        public double? DigitField3 { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? StringField1 { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? StringField2 { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? StringField3 { get; set; }
        [Column(TypeName = "text")]
        public string? MarkdownField1 { get; set; }
        [Column(TypeName = "text")]
        public string? MarkdownField2 { get; set; }
        [Column(TypeName = "text")]
        public string? MarkdownField3 { get; set; }
        public DateTime? DateField1 { get; set; }
        public DateTime? DateField2 { get; set; }
        public DateTime? DateField3 { get; set; }
        public bool? BoolField1 { get; set; }
        public bool? BoolField2 { get; set; }
        public bool? BoolField3 { get; set; }
        public List<Comment> Comments { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
        public List<Like> Likes { get; set; } = new();
        public string CollectionId { get; set; }
        public Collection? Collection { get; set; }
    }
}
