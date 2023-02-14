using CollectionManager.Data;

namespace CollectionManager.Repositories.Abstract
{
    public interface ITopicService
    {
        bool Add(Topic model);
        bool Update(Topic model);
        bool Delete(int id);
        Topic FindById(int id);
        IEnumerable<Topic> GetAll();
    }
}
