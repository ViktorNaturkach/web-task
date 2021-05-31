using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.ViewModels.Shop;
using WebTask.Common.Constants;
using System;
using WebTask.Common.Enums;

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
        public IActionResult Products(int itemsCount = 0, int itemsPerPage = CommonConstants.ITEMS_PER_PAGE, PSort pSort = CommonConstants.SORT_BY_DEFAULT)
        {
            var productsDTO = _productService.GetProducts(itemsCount, itemsPerPage, pSort);
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(productsDTO);
            var count = _productService.GetAllProductsCount();
            IndexViewModel viewModel = new IndexViewModel
            {
                TotalProducts = count,
                Products = products
            };
            return PartialView("_Products", viewModel);
        }
    }
}
