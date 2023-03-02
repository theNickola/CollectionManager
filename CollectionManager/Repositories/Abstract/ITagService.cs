using CollectionManager.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionManager.Repositories.Abstract
{
    public interface ITagService
    {
        bool AddTagsToIthem(string[] tags, string ithemId);
        Tag? FindById(string id);
        IEnumerable<Tag> GetAll();
        byte GetMaxCountTagsIthem();
    }
}
