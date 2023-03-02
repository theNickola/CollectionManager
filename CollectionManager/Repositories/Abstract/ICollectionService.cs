using CollectionManager.Models.Domain;

namespace CollectionManager.Repositories.Abstract
{
    public interface ICollectionService
    {
        bool Add(Collection model);
        bool Update(Collection model);
        bool Delete(string id);
        Collection? FindById(string id);
        IEnumerable<Collection> GetUserCollections(string identityName);
        List<string> GetNamesGroupOptionalFields();
        byte GetCountOptionalFieldsInGroup();
        Dictionary<string, string[]> GetNamesValuesOptionalFields(string id);
    }
}
