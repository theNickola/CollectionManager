using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CollectionManager.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
