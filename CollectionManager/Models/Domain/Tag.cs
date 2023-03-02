using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.Models.Domain
{
    public class Tag
    {
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<Ithem> Ithems { get; set; } = new();
    }
}
