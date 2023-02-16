using CollectionManager.Data;

namespace CollectionManager.Repositories.Abstract
{
    public interface IAccessService
    {
        Task<bool> IsExistUser(string UserNameFromClaims);
        Task<bool> IsActiveUser(string UserNameFromClaims);
        Task<bool> IsInAdminRole(string UserNameFromClaims);
        Task<bool> IsUserRule(string UserNameFromClaims);
    }
}
