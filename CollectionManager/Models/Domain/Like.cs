using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.Models.Domain
{
    public class Like
    {
        public string IthemId { get; set; }
        public Ithem Ithem { get; set; }
        [Column(TypeName = "varchar(36)")]
        public string UserId { get; set; }
    }
}
