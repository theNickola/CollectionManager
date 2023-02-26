using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Repositories.Implementation
{
    [Authorize]
    public class CollectionService : ICollectionService
    {
        private readonly ApplicationDbContext _context;
        public CollectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Collection model)
        {
            try
            {
                _context.Collections.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Collection model)
        {
            try
            {
                _context.Collections.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var collection = this.FindById(id);
                if (collection == null)
                    return false;
                _context.Remove(collection);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Collection FindById(string id)
        {
            return _context.Collections.Find(id);
        }
        public IEnumerable<Collection> GetUserCollections(string identityName)
        {
            var data = _context.Collections.Include(c => c.User).Include(c => c.Topic).ToList();
            var collections = data.Where(c => c.User.Email == identityName);
            return collections;
        }
        public List<string> GetNamesGroupOptionalFields()
        {
            return new List<string>() { "Digit", "String", "Markdown", "Date", "Bool" };
        }
        public byte GetCountOptionalFieldsInGroup()
        {
            return 3;
        }
    }
}
