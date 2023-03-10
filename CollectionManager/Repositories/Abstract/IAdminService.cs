using CollectionManager.Models.Admin;
using CollectionManager.Models.Domain;

namespace CollectionManager.Repositories.Abstract
{
    public interface IAdminService
    {
        bool AddAdminRole(string id);
        bool RemoveAdminRole(string id);
        bool Block(string id);
        bool Unblock(string id);
        bool Delete(string id);
        User? FindById(string id);
        IEnumerable<UserInfo> GetAll();
    }
}
