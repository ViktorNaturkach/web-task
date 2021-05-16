using Microsoft.AspNetCore.Mvc;
using WebTask.EFData;

namespace WebTask.Controllers
{
    public class ShopController : Controller
    {
        private IProductRepository repository;

        public ShopController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.GetProducts());
        }
    }
}
