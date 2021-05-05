using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Models;

namespace WebTask.Controllers
{
    public class ShopController : Controller
    {
        private IDataRepository repository;

        public ShopController(IDataRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.GetProducts());
        }
    }
}
