using CollectionManager.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionManager.Repositories.Abstract
{
    public interface IIthemService
    {
        bool Add(Ithem model);
        bool Update(Ithem model);
        bool Delete(string id);
        Ithem? FindById(string id);
        IEnumerable<Ithem> GetIthemsCollection(string idCollection);
        IEnumerable<Ithem> GetLastIthems();
        Ithem? GetIthemWithIncludes(string id);
    }
}
