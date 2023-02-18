using CollectionManager.Data;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CollectionManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class TopicController : Controller
    {
        private readonly ITopicService _service;
        private readonly IAccessService _accessService;
        public TopicController(ITopicService service, IAccessService accessService)
        {
            _service = service;
            _accessService = accessService;
        }
        public IActionResult Index()
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            var topics = _service.GetAll();
            return View(topics);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Topic model)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Add(model);
            if(result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            var topic = _service.FindById(id);
            return View(topic);
        }
        [HttpPost]
        public IActionResult Update(Topic model)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Update(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            var result = _service.Delete(id);
            if (!result) TempData["msg"] = "Operation error";
            return RedirectToAction("Index");
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
