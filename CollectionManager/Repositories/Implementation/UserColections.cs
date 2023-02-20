using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace CollectionManager.Repositories.Implementation
{
    [Authorize]
    public class UserColections : IUserCollections
    {
        public bool Add(Collection model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Collection FindById(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Collection> GetUserCollections()
        {
            throw new NotImplementedException();
        }
        public bool Update(Collection model)
        {
            throw new NotImplementedException();
        }
    }
}
