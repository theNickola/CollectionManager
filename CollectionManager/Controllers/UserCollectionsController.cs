using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionManager.Controllers
{
    public class UserCollectionsController : Controller
    {
        private readonly IAccessService _accessService;
        private readonly ICollectionService _collectionService;
        private readonly ITopicService _topicService;
        private readonly UserManager<User> _userManager;
        public UserCollectionsController
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

        public IActionResult Index(string userName)
        {
            ViewBag.UserName = userName;
            return View(_collectionService.GetUserCollections(userName));
        }
        public IActionResult Add(string userName)
        {
            SetDataForAddCollection(userName);
            return View();
        }
        [HttpPost]
        public IActionResult Add(Collection model)
        {
            //if (!IsUserAcess())
            //    return Redirect("/Identity/Account/AccessDenied");
            var result = _collectionService.Add(model);
            string userName = _userManager.FindByIdAsync(model.UserId).Result.UserName;
            SetDataForAddCollection(userName);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return Redirect("/UserCollections/Add?userName="+userName);
            }
            TempData["msg"] = "Error has occured on server side";
            return Redirect("/UserCollections/Add?userName=" + userName);
        }
        public IActionResult Delete(string id, string userName)
        {
            //if (!IsAdminAcess())
            //    return Redirect("/Identity/Account/AccessDenied");
            var result = _collectionService.Delete(id);
            if (!result) 
                TempData["msg"] = "Deletion error";
            return Redirect($"/UserCollections/Index?userName={userName}");
        }
        private void SetDataForAddCollection(string userName)
        {
            ViewBag.UserId = _userManager.FindByEmailAsync(userName).Result.Id;
            ViewBag.UserName = userName;
            SelectList topicSeectList = _topicService.GetSelectList();
            ViewBag.Topics = topicSeectList;
            ViewBag.NamesGroupOptionalFields = _collectionService.GetNamesGroupOptionalFields();
            ViewBag.GetCountOptionalFieldsInGroup = _collectionService.GetCountOptionalFieldsInGroup();
        }

        private bool IsUserAcess()
        {
            try
            {
                if (!_accessService.IsUserRule(User.Identity.Name).Result)
                {
                    return false;
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
