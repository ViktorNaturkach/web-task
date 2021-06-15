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
            var model = _mapper.Map<UpdateDetailsViewModel>(productDTO);
            var categories = await _categoryService.GetCategoriesAsync();
            var allCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            var types = await _typeService.GetTypesAsync();
            var sizes = await _sizeService.GetSizesAsync();
            var allSizes = _mapper.Map<IEnumerable<SizeViewModel>>(sizes);
            var allTypes = _mapper.Map<IEnumerable<TypeViewModel>>(types);
            foreach (var item in allSizes){
                item.Cheked = productDTO.Sizes.ToList().Exists(x => x.Id == item.Id);
            }
            foreach (var item in allTypes)
            {
                item.Cheked = productDTO.Types.ToList().Exists(x => x.Id == item.Id);
            }
            
            model.AllSizes = allSizes.ToList();
            model.AllTypes = allTypes.ToList();
            //model.AllTypes = allTypes.Select(n => n.Name).ToList();
            //model.Types =productDTO.Types.Select(n => n.Name).ToList();
            model.AllCategories = new SelectList(allCategories, "Id", "Name", productDTO.Category.Id);
            //var model = new UpdateDetailsViewModel()
            //{
            //    ViewDetails = viewDetails,
            //    AllCategories = new SelectList(allCategories, "Id", "Name", productDTO.Category.Id),
            //    AllTypes = allTypes,
            //    AllSizes = allSizes
            //};
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateDetails(UpdateDetailsViewModel model)
        {
            //var productDTO = await _productService.GetProductDetailAsync(id);
    //          var productDTO = _mapper.Map<ViewDetailsViewModel>(model);
            return View();
        }

    }
}
