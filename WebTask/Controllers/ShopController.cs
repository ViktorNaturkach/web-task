using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.ViewModels.Shop;
using WebTask.Common.Constants;
using System;
using WebTask.Common.Enums;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO.DTO.Shop;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Products(ProductFilterDTO filters)
        {
            var productsDTO = await _productService.GetProductsAsync(filters);
            var count = await _productService.GetProductsCountWhereAsync(filters);
            var minPrice = await _productService.GetMinProductPriceAsync(filters);
            var maxPrice = await _productService.GetMaxProductPriceAsync(filters);
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(productsDTO);
            IndexViewModel viewModel =  new IndexViewModel
            {
                TotalProducts = count,
                MinPrice = (int) Math.Floor(minPrice),
                MaxPrice = (int) Math.Ceiling(maxPrice),
                Products = products
            };
            return PartialView("_Products", viewModel);
        }
    }
}
