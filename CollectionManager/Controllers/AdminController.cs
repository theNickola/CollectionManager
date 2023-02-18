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
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            var users = _service.GetAll();
            ViewData["NameAdminRole"] = RolesInit.GetNameAdminRole();
            return View(users);
        }
        public IActionResult Block(string id)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            IsUserAcess();
            _service.Block(id);
            return RedirectToAction("Index");

        }
        public IActionResult Unblock(string id)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            _service.Unblock(id);
            return RedirectToAction("Index");
        }
        public IActionResult AddAdminRole(string id)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            _service.AddAdminRole(id);
            return RedirectToAction("Index");
        }        
        public IActionResult RemoveAdminRole(string id)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            _service.RemoveAdminRole(id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
            if (!IsUserAcess())
                return Redirect("/Identity/Account/AccessDenied");
            _service.Delete(id);
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
