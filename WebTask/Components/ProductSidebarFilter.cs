using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.InfrastructureDTO.DTO.Shop;
using WebTask.ViewModels.Shop;

namespace WebTask.Components
{
    public class ProductSidebarFilter : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ITypeService _typeService;
        private readonly ISizeService _sizeService;
        private readonly IProductService _productService;
        public ProductSidebarFilter(IMapper mapper, IProductService productService, ICategoryService categoryService, ITypeService typeService, ISizeService sizeService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _typeService = typeService;
            _productService = productService;
            _sizeService = sizeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            var types = await _typeService.GetTypesAsync();
            var sizes = await _sizeService.GetSizesAsync();
            var minPrice = await _productService.GetMinProductPriceAsync(new ProductFilterDTO ());
            var maxPrice = await _productService.GetMaxProductPriceAsync(new ProductFilterDTO());
            ProductFilterViewModel model = new ProductFilterViewModel()
            {
                Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories),
                Types = _mapper.Map<IEnumerable<TypeViewModel>>(types),
                Sizes = _mapper.Map<IEnumerable<SizeViewModel>>(sizes),
                MinPrice = (int) Math.Floor(minPrice),
                MaxPrice = (int) Math.Ceiling(maxPrice)
            };
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return View();
            }

        }
    }
}
