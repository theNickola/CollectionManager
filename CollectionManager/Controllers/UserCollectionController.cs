using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionManager.Controllers
{
    [Authorize]
    public class UserCollectionController : Controller
    {
        private readonly IAccessService _accessService;
        private readonly ICollectionService _collectionService;
        private readonly ITopicService _topicService;
        private readonly UserManager<User> _userManager;
        public UserCollectionController
            (
            ICollectionService collectionService, 
            ITopicService topicService, 
            IAccessService accessService, 
            UserManager<User> userManager
            )
        {
            _collectionService = collectionService;
            _topicService = topicService;
            _accessService = accessService;
            _userManager = userManager;
        }

        public IActionResult Index(string authorName)
        {
            ViewBag.AuthorName = authorName;
            return View(_collectionService.GetUserCollections(authorName));
        }
        public IActionResult Add(string authorName)
        {
            SetDataForAddCollection(authorName);
            return View();
        }
        [HttpPost]
        public IActionResult Add(Collection model)
        {
            string authorName = _userManager.FindByIdAsync(model.UserId).Result.UserName;
            if (!IsUserAccess(authorName))
                return Redirect("/Identity/Account/AccessDenied");
            SetDataForAddCollection(authorName);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _collectionService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return Redirect($"/UserCollection/Add?authorName={authorName}");
            }
            TempData["msg"] = "Error has occured on server side";
            return Redirect($"/UserCollection/Add?authorName={authorName}");
        }
        public IActionResult Delete(string id, string authorName)
        {
            if (!IsUserAccess(authorName))
                return Redirect("/Identity/Account/AccessDenied");
            var result = _collectionService.Delete(id);
            if (!result) 
                TempData["msg"] = "Deletion error";
            return Redirect($"/UserCollection/Index?authorName={authorName}");
        }
        private void SetDataForAddCollection(string authorName)
        {
            ViewBag.AuthorId = _userManager.FindByEmailAsync(authorName).Result.Id;
            ViewBag.authorName = authorName;
            SelectList topicSeectList = _topicService.GetSelectList();
            ViewBag.Topics = topicSeectList;
            ViewBag.NamesGroupOptionalFields = _collectionService.GetNamesGroupOptionalFields();
            ViewBag.GetCountOptionalFieldsInGroup = _collectionService.GetCountOptionalFieldsInGroup();
        }

        private bool IsUserAccess(string authorName)
        {
            try
            {
                if (authorName == User.Identity?.Name)
                {
                    if (!_accessService.IsUserRule(User.Identity?.Name).Result)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!_accessService.IsAdminRule(User.Identity?.Name).Result)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
