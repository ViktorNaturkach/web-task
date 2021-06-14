using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.ViewModels.Product;
using WebTask.ViewModels.Shop;

namespace WebTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ITypeService _typeService;
        private readonly ISizeService _sizeService;
        public ProductController(IMapper mapper, IProductService productService, IUserInfoService userInfoService, ICategoryService categoryService, ITypeService typeService, ISizeService sizeService)
        {
            _mapper = mapper;
            _productService = productService;
            _userInfoService = userInfoService;
            _categoryService = categoryService;
            _typeService = typeService;
            _sizeService = sizeService;
        }

        public async Task<ActionResult> Details(long id)
        {
            if (await _userInfoService.UserInRoleAsync(HttpContext.User,"Admin"))
            {
                return  RedirectToAction("UpdateDetails", "Product", new { id = id });
            }
            return  RedirectToAction("ViewDetails", "Product", new { id = id });
         }
        public async Task<IActionResult> ViewDetails(long id)
        {
            var productDTO = await _productService.GetProductDetailAsync(id);
            var model = _mapper.Map<ViewDetailsViewModel>(productDTO);
            return View(model);
        }
        public async Task<IActionResult> UpdateDetails(long id)
        {
            var productDTO = await _productService.GetProductDetailAsync(id);
            var viewDetails = _mapper.Map<ViewDetailsViewModel>(productDTO);
            var categories = await _categoryService.GetCategoriesAsync();
            var allCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            var types = await _typeService.GetTypesAsync();
            var sizes = await _sizeService.GetSizesAsync();
            var model = new UpdateDetailsViewModel()
            {
                ViewDetails = viewDetails,
                AllCategories = new SelectList(allCategories, "Id", "Name", productDTO.Category.Id),
                AllTypes = _mapper.Map<IEnumerable<TypeViewModel>>(types),
                AllSizes = _mapper.Map<IEnumerable<SizeViewModel>>(sizes)
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDetails(UpdateDetailsViewModel model)
        {
            //var productDTO = await _productService.GetProductDetailAsync(id);
            //var model = _mapper.Map<ViewDetailsViewModel>(productDTO);
            return View();
        }

    }
}
