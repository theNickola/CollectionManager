using Azure;
using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;

namespace CollectionManager.Repositories.Implementation
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _context;
        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(string userId, string ithemId)
        {
            try
            {
                var like = Create(userId, ithemId);
                _context.Likes.Add(like);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(string userId, string ithemId)
        {
            try
            {
                var like = Create(userId, ithemId);
                _context.Likes.Remove(like);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private Like Create(string userId, string ithemId)
        {
            return new Like
            {
                UserId=userId,
                IthemId=ithemId
            };
        }
        public bool IsLike(string userId, string ithemId)
        {
            return _context.Likes.Any(l => l.UserId == userId && l.IthemId == ithemId);
        }
        public int SumLikes(string ithemId)
        {
            return _context.Likes.Where(l => l.IthemId == ithemId).Count();
        }
    }
}
