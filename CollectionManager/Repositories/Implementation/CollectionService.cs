using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Repositories.Implementation
{
    [Authorize]
    public class CollectionService : ICollectionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminService _adminService;
        public CollectionService(ApplicationDbContext context, IAdminService adminService)
        {
            _context = context;
            _adminService = adminService;
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
        public Collection? FindById(string id)
        {
            return _context.Collections?.Find(id);
        }
        public IEnumerable<Collection> GetUserCollections(string identityName)
        {
            var data = _context.Collections.Include(c => c.User).Include(c => c.Topic).ToList();
            var collections = data.Where(c => c.User.Email == identityName).OrderBy(c => c.Name);
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
        public Dictionary<string, string[]> GetNamesValuesOptionalFields(string id)
        {
            var collection = FindById(id);
            var namesValues = new Dictionary<string, string[]>
            {
                { "DigitField", new string[] {
                    collection.NameDigitField1,
                    collection.NameDigitField2,
                    collection.NameDigitField3 }
                },
                { "StringField", new string[] {
                    collection.NameStringField1,
                    collection.NameStringField2,
                    collection.NameStringField3 }
                },
                { "MarkdownField", new string[] {
                    collection.NameMarkdownField1,
                    collection.NameMarkdownField2,
                    collection.NameMarkdownField3 }
                },
                { "DateField", new string[] {
                    collection.NameDateField1,
                    collection.NameDateField2,
                    collection.NameDateField3 }
                },
                { "BoolField", new string[] {
                    collection.NameBoolField1,
                    collection.NameBoolField2,
                    collection.NameBoolField3 }
                }
            };
            return namesValues;
        }
    }
}
