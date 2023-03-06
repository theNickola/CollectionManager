using CollectionManager.Data;
using CollectionManager.Models;
using CollectionManager.Models.ViewModels;
using CollectionManager.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollectionManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIthemService _ithemService;
        private readonly ICollectionService _collectionService;
        public HomeController(IIthemService ithemService, ICollectionService collectionService)
        {
            _ithemService = ithemService;
            _collectionService = collectionService;
        }

        public IActionResult Index()
        {
            DataStartPage forStartPage = new()
            {
                LastItems = _ithemService.GetLastIthems(),
                BigCollections = _collectionService.GetBigCollections(),
                AllCollections = _collectionService.GetAll()
            };
            return View(forStartPage);
        }
        public IActionResult Ithem(string id)
        {
            IthemPage ithemPage = new()
            {
                Ithem = _ithemService.GetIthemWithIncludes(id),
                Tags = _ithemService.GetTags(id),
                Comments = _ithemService.GetComments(id)
            };
            return View(ithemPage);
        }
        public IActionResult Collection(string id)
        {
            return View(_collectionService.GetCollectionWithInclude(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}