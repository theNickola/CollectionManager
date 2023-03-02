using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using CollectionManager.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManager.Controllers
{
    [Authorize]
    public class IthemController : Controller
    {
        private readonly ICollectionService _collectionService;
        private readonly IIthemService _ithemService;
        private readonly IAdminService _adminService;
        private readonly ITagService _tagService;
        private readonly IAccessService _accessService;
        public IthemController(
            ICollectionService collectionService,
            IIthemService ithemService,
            IAdminService adminService,
            ITagService tagService,
            IAccessService accessService)
        {
            _collectionService = collectionService;
            _ithemService = ithemService;
            _adminService = adminService;
            _tagService = tagService;
            _accessService = accessService;
        }

        public IActionResult Index(string collectionId)
        {
            SetDataForAddIthem(collectionId);
            return View(_ithemService.GetIthemsCollection(collectionId));
        }
        public IActionResult Add(string collectionId)
        {
            SetDataForAddIthemAndOptionalFields(collectionId);
            return View();
        }
        [HttpPost]
        public IActionResult Add(Ithem model, string[] ItemTagss)
        {
            Collection? collection = _collectionService.FindById(model.CollectionId);
            if (!IsUserAccess(_adminService.FindById(collection.UserId).UserName))
                return Redirect("/Identity/Account/AccessDenied");
            SetDataForAddIthemAndOptionalFields(model.CollectionId);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _ithemService.Add(model);
            if (result)
            {
                var resultAddTags = _tagService.AddTagsToIthem(ItemTagss, model.Id);
                if (resultAddTags)
                {
                    TempData["msg"] = "Added Successfully";
                    return Redirect($"/Ithem/Add?collectionId={model.CollectionId}");
                }
            }
            TempData["msg"] = "Error has occured on server side";
            return Redirect($"/Ithem/Add?collectionId={model.CollectionId}");
        }
        public IActionResult Update(string id)
        {
            var topic = _ithemService.FindById(id);
            return View(topic);
        }
        [HttpPost]
        public IActionResult Update(Ithem model)
        {
            if (!IsUserAccess(_collectionService.FindById(model.CollectionId).User.UserName))
                return Redirect("/Identity/Account/AccessDenied");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _ithemService.Update(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Delete(string id, string collectionId)
        {
            if (!IsUserAccess(_collectionService.FindById(collectionId).User.UserName))
                return Redirect("/Identity/Account/AccessDenied");
            var result = _ithemService.Delete(id);
            if (!result)
                TempData["msg"] = "Deletion error";
            return Redirect($"/Ithem/Index?collectionId={collectionId}");
        }
        private void SetDataForAddIthem(string collectionId)
        {
            ViewBag.CollectionId = collectionId;
            Collection? collection = _collectionService.FindById(collectionId);
            ViewBag.Collection = collection;
            ViewBag.CollectionName = collection?.Name;
            ViewBag.AuthorName = _adminService?.FindById(collection?.UserId)?.UserName;
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.CountTags = _tagService.GetMaxCountTagsIthem();
        }
        private void SetDataForAddIthemAndOptionalFields(string collectionId)
        {
            SetDataForAddIthem(collectionId);
            ViewBag.CountOptionalFieldsInGroup = _collectionService.GetCountOptionalFieldsInGroup();
            ViewBag.OptionalCollectionFields = _collectionService.GetNamesValuesOptionalFields(collectionId);
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
