using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.Models.Domain
{
    public class Comment
    {
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TextComment { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string IthemId { get; set; }
        public Ithem? Ithem { get; set; }
        [Column(TypeName = "varchar(36)")]
        public string UserId { get; set; }
    }
}
