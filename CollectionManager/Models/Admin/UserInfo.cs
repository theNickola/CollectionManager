using CollectionManager.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace CollectionManager.Models.Admin
{
    public class UserInfo : User
    {
        public UserInfo(User user)
        {
            this.Id = user.Id;
            this.Active = user.Active;
            this.UserName = user.UserName;
            this.Name = user.Name; 
            this.Email = user.Email;
        }
        public string? Roles { get; set; }
    }
}
