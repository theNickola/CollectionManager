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
            return View(_ithemService.GetIthemWithIncludes(id));
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