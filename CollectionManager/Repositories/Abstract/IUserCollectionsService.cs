using CollectionManager.Models.Domain;

namespace CollectionManager.Repositories.Abstract
{
    public interface IUserCollections
    {
        bool Add(Collection model);
        bool Update(Collection model);
        bool Delete(int id);
        Collection FindById(int id);
        IEnumerable<Collection> GetUserCollections();
    }
}
