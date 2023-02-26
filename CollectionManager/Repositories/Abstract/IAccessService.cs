using CollectionManager.Data;

namespace CollectionManager.Repositories.Abstract
{
    public interface IAccessService
    {
        Task<bool> IsUserRule(string identityUserName);
        Task<bool> IsAdminRule(string identityUserName);
    }
}
