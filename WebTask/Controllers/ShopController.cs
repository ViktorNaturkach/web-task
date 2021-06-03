using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.ViewModels.Shop;
using WebTask.Common.Constants;
using System;
using WebTask.Common.Enums;
using System.Threading.Tasks;

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
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Products(int itemsCount = 0, int itemsPerPage = CommonConstants.ITEMS_PER_PAGE, PSort pSort = CommonConstants.SORT_BY_DEFAULT)
        {
            
            var productsDTO = await _productService.GetProductsAsync(itemsCount, itemsPerPage, pSort);
            var count = await _productService.GetAllProductsCount();
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(productsDTO);
            IndexViewModel viewModel =  new IndexViewModel
            {
                TotalProducts = count,
                Products = products
            };
            return PartialView("_Products", viewModel);
        }
    }
}
