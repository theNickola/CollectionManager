using CollectionManager.Models.Domain;

namespace CollectionManager.Repositories.Abstract
{
    public interface ITopicService
    {
        bool Add(Topic model);
        bool Update(Topic model);
        bool Delete(string id);
        Topic FindById(string id);
        IEnumerable<Topic> GetAll();
    }
}
