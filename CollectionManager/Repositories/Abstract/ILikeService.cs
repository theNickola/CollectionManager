using CollectionManager.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionManager.Repositories.Abstract
{
    public interface ILikeService
    {
        bool Add(string userId, string ithemId);
        bool IsLike(string userId, string ithemId);
        int SumLikes(string ithemId);
        bool Remove(string userId, string ithemId);
    }
}
