using Azure;
using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;

namespace CollectionManager.Repositories.Implementation
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _context;
        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddTagsToIthem(string[] itemTags, string ithemId)
        {
            try
            {
                Ithem? ithem = _context.Ithems.Find(ithemId);
                for (int i = 0; i < itemTags.Length; i++)
                    if (itemTags[i] != null)
                        TagToIthem(itemTags[i], ithem);
                return true;
            }
            catch
            {
                return false;

            }
        }
        public Tag? FindById(string id)
        {
            return _context.Tags?.Find(id);
        }
        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.ToList().OrderBy(t => t.Name);
        }
        public byte GetMaxCountTagsIthem()
        {
            return 5;
        }
        private void TagToIthem(string nameTag, Ithem ithem)
        {
            Tag? tag = FindByName(nameTag);
            if (tag == null)
                CreateAttachToIthem(nameTag, ithem);
            else
                AttachToIthem(tag, ithem);
        }
        private void AttachToIthem(Tag tag, Ithem ithem)
        {
            tag.Ithems.Add(ithem);
            _context.Tags.Update(tag);
            _context.SaveChanges();
        }
        private void CreateAttachToIthem(string nameTag, Ithem ithem)
        {
            var tag = new Tag() { Name = nameTag, Ithems = { ithem } };
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
        private Tag? FindByName(string name)
        {
            if (_context.Tags.Any(t => t.Name == name))
                return _context.Tags.First(t => t.Name == name);
            else
                return null;
        }
    }
}
