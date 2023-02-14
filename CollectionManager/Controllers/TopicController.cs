using CollectionManager.Data;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CollectionManager.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class TopicController : Controller
    {
        private readonly ITopicService _service;
        public TopicController(ITopicService service)
        {
            _service = service;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Topic model)
        {
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
            var record = _service.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Topic model)
        {
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
            var result = _service.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
    }
}
