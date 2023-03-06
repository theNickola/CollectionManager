using Azure;
using CollectionManager.Data;
using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;

namespace CollectionManager.Repositories.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(string text, string userId, DateTime date, string ithemId)
        {
            try
            {
                var comment = Create(text, userId, date, ithemId);
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private Comment Create(string text, string userId, DateTime date, string ithemId)
        {
            return new Comment
            {
                TextComment = text,
                UserId = userId,
                DateCreation = date,
                IthemId = ithemId
            };
        }
    }
}
