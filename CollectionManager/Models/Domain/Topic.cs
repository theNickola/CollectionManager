using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.Models.Domain
{
    public class Topic
    {
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; } = "Some description ...";
        public List<Collection> Collections { get; set; } = new();
    }
}
