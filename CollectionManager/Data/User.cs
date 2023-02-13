using Microsoft.AspNetCore.Identity;

namespace CollectionManager.Data
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public string Language { get; set; } = "En";
    }
}