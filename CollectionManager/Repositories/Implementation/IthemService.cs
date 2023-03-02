using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Repositories.Implementation
{
    public class IthemService : IIthemService
    {
        private readonly ApplicationDbContext _context;
        public IthemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Ithem model)
        {
            try
            {
                _context.Ithems.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Ithem model)
        {
            try
            {
                _context.Ithems.Update(model);
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
                var ithem = this.FindById(id);
                if (ithem == null)
                    return false;
                _context.Remove(ithem);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Ithem? FindById(string id)
        {
            return _context.Ithems?.Find(id);
        }
        public IEnumerable<Ithem> GetIthemsCollection(string idCollection)
        {
            return _context.Ithems.ToList().Where(ithem => ithem.CollectionId == idCollection).OrderBy(i => i.Name);
        }
        public IEnumerable<Ithem> GetLastIthems()
        {
            return _context.Ithems.ToList().OrderByDescending(ithem => ithem.DateCreation).Take(CountLastIthems());
        }
        private byte CountLastIthems()
        {
            return 10;
        }
        public Ithem? GetIthemWithIncludes(string id)
        {
            var ithemInList = _context.Ithems
                .Include(i => i.Collection).ThenInclude(c => c.User)
                .Include(i => i.Tags)
                .ToList();
            return ithemInList.First(i => i.Id == id);
        }
    }
}
