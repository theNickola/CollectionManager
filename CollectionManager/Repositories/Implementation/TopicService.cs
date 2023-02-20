using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;

namespace CollectionManager.Repositories.Implementation
{
    public class TopicService : ITopicService
    {
        private readonly ApplicationDbContext _context;
        public TopicService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Topic model)
        {
            try
            {
                _context.Topics.Add(model);
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
                var topic = this.FindById(id);
                if (topic == null)
                    return false;
                _context.Remove(topic);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Topic? FindById(string id)
        {
            return _context.Topics.Find(id);
        }
        public IEnumerable<Topic> GetAll()
        {
            return _context.Topics.ToList();
        }
        public bool Update(Topic model)
        {
            try
            {
                _context.Topics.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
