using CollectionManager.Data;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManager.Controllers
{
    [Authorize(Roles ="admin,user")]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        private readonly IAccessService _accessService;
        public AdminController(IAdminService service, IAccessService accessService)
        {
            _service = service;
            _accessService = accessService;
        }

        public IActionResult Index()
        {
            try
            {
                if (!_accessService.IsUserRule(User.Identity.Name).Result)
                    return Redirect("/Identity/Account/AccessDenied");
            }
            catch 
            { 
                return Redirect("/Identity/Account/AccessDenied"); 
            }
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
