using CollectionManager.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionManager.Repositories.Abstract
{
    public interface ICommentService
    {
        bool Add(string text, string userId, DateTime date, string ithemId);
    }
}
