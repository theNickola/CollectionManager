using CollectionManager.Data;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManager.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var users = _service.GetAll();
            ViewData["NameAdminRole"] = RolesInit.GetNameAdminRole();
            return View(users);
        }
        public IActionResult Block(string id)
        {
            var result = _service.Block(id);
            if (!result) TempData["msg"] = "Operation error";
            return RedirectToAction("Index");

        }
        public IActionResult Unblock(string id)
        {
            var result = _service.Unblock(id);
            if (!result) TempData["msg"] = "Operation error";
            return RedirectToAction("Index");
        }
        public IActionResult AddAdminRole(string id)
        {
            var result = _service.AddAdminRole(id);
            if (!result) TempData["msg"] = "Operation error";
            return RedirectToAction("Index");
        }        
        public IActionResult RemoveAdminRole(string id)
        {
            var result = _service.RemoveAdminRole(id);
            if (!result) TempData["msg"] = "Operation error";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
            var result = _service.Delete(id);
            if (!result) TempData["msg"] = "Operation error";
            return RedirectToAction("Index");
        }
    }
}
