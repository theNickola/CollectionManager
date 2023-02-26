using CollectionManager.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionManager.Repositories.Abstract
{
    public interface ITopicService
    {
        bool Add(Topic model);
        bool Update(Topic model);
        bool Delete(string id);
        Topic FindById(string id);
        IEnumerable<Topic> GetAll();
        SelectList GetSelectList();
    }
}
