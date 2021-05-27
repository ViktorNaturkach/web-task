using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.ViewModels.Shop;
using WebTask.Common.Constants;
using System;

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
        public IActionResult Products(int itemsCount = 0, int itemsPerPage = CommonConstants.ITEMS_PER_PAGE)
        {
            var productsDTO = _productService.GetProducts(itemsCount, itemsPerPage);
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(productsDTO);
            var count = _productService.GetAllProductsCount();
            var pagesCount = (int)Math.Ceiling(count / (double)itemsPerPage);
            IndexViewModel viewModel = new IndexViewModel
            {
                TotalProducts = count,
                Products = products
            };
            return PartialView("_Products", viewModel);
        }
    }
}
