using CollectionManager.Models.Domain;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IAccessService _accessService;
        public TopicController(ITopicService topicService, IAccessService accessService)
        {
            _topicService = topicService;
            _accessService = accessService;
        }
        public IActionResult Index()
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            var topics = _topicService.GetAll();
            return View(topics);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Topic model)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _topicService.Add(model);
            if(result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Update(string id)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            var topic = _topicService.FindById(id);
            return View(topic);
        }
        [HttpPost]
        public IActionResult Update(Topic model)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _topicService.Update(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Delete(string id)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            var result = _topicService.Delete(id);
            if (!result) 
                TempData["msg"] = "Deletion error";
            return RedirectToAction("Index");
        }
        private bool IsAdminAccess()
        {
            try
            {
                if (!_accessService.IsAdminRule(User.Identity.Name).Result)
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
