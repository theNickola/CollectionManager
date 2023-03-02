using CollectionManager.Data;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManager.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAccessService _accessService;
        public AdminController(IAdminService adminService, IAccessService accessService)
        {
            _adminService = adminService;
            _accessService = accessService;
        }

        public IActionResult Index()
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            var users = _adminService.GetAll();
            ViewData["NameAdminRole"] = RolesInit.GetNameAdminRole();
            return View(users);
        }
        public IActionResult Block(string id)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            _adminService.Block(id);
            return RedirectToAction("Index");

        }
        public IActionResult Unblock(string id)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            _adminService.Unblock(id);
            return RedirectToAction("Index");
        }
        public IActionResult AddAdminRole(string id)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            _adminService.AddAdminRole(id);
            return RedirectToAction("Index");
        }        
        public IActionResult RemoveAdminRole(string id)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            _adminService.RemoveAdminRole(id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
            if (!IsAdminAccess())
                return Redirect("/Identity/Account/AccessDenied");
            _adminService.Delete(id);
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
