using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.ViewModels.Shop;

namespace WebTask.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ShopController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var productsDTO = _productService.GetProducts();
            var model = _mapper.Map<ProductListViewModel>(productsDTO);
            return View(model.products);
        }
    }
}
