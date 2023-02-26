using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.Models.Domain
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public string Language { get; set; } = "En";
        public DateTime DateRegistration { get; set; } = DateTime.Now;
        public List<Collection> Collections { get; set; } = new();
        public List<IdentityRole> ListRoles { get; set; } = new();
    }
}