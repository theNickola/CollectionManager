using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace CollectionManager.Repositories
{
    public class CommentHub : Hub
    {
        private readonly UserManager<User> _userManager;
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;
        public CommentHub(UserManager<User> userManager, ICommentService commentService, ILikeService likeService)
        {
            _userManager = userManager;
            _commentService = commentService;
            _likeService = likeService;
        }

        public async Task Send(string commentText, string userName, string ithemId)
        {
            var user = await _userManager.FindByNameAsync(userName);
            string nameUser = user.Name;
            DateTime dateAdded = DateTime.Now;
            var result = _commentService.Add(commentText, nameUser, dateAdded, ithemId);
            if (result)
                await this.Clients.All.SendAsync("Receive", commentText, nameUser, dateAdded.ToString(), ithemId);
        }

        public async Task Like(string userName, string ithemId)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (!_likeService.IsLike(user.Id, ithemId))
            {
                if(_likeService.Add(user.Id, ithemId))
                    await this.Clients.All.SendAsync("ReceiveLike", userName, ithemId, "del", _likeService.SumLikes(ithemId));
            }
            else
            {
                if (_likeService.Remove(user.Id, ithemId))
                    await this.Clients.All.SendAsync("ReceiveLike", userName, ithemId, "add", _likeService.SumLikes(ithemId));
            }
        }
        public async Task IsLiked(string userName, string ithemId)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var sum = _likeService.SumLikes(ithemId);
            bool isLike = _likeService.IsLike(user.Id, ithemId);
            await this.Clients.All.SendAsync("ReceiveIsLiked", userName, ithemId, isLike, sum);
        }
    }
}
