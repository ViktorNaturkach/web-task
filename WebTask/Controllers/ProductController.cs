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
using WebTask.InfrastructureDTO.DTO.Product;
using WebTask.InfrastructureDTO.DTO.Shop;
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
            var categories = await _categoryService.GetCategoriesAsync();
            var types = await _typeService.GetTypesAsync();
            var sizes = await _sizeService.GetSizesAsync();
            var allCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            var allSizes = _mapper.Map<IEnumerable<SizeViewModel>>(sizes);
            var allTypes = _mapper.Map<IEnumerable<TypeViewModel>>(types);
            var model = _mapper.Map<UpdateDetailsViewModel>(productDTO);
            foreach (var item in allSizes){
                item.Cheked = productDTO.Sizes.ToList().Exists(x => x.Id == item.Id);
            }
            foreach (var item in allTypes)
            {
                item.Cheked = productDTO.Types.ToList().Exists(x => x.Id == item.Id);
            }
            model.AllSizes = allSizes.ToList();
            model.AllTypes = allTypes.ToList();
            model.AllCategories = new SelectList(allCategories, "Id", "Name", productDTO.Category.Id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDetails(UpdateDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var detailDTO = _mapper.Map<DetailDTO>(model);
                var sizes = model.AllSizes.Where(s => s.Cheked).ToList();
                foreach (var item in sizes)
                {
                    detailDTO.Sizes.Add(new SizeDTO { Id = item.Id, Name = item.Name });
                }
                var types = model.AllTypes.Where(t => t.Cheked).ToList();
                foreach (var item in types)
                {
                    detailDTO.Types.Add(new TypeDTO { Id = item.Id, Name = item.Name });
                }
                var result = await _productService.UpdateProductAsync(detailDTO);
                if (result)
                {
                    return RedirectToAction("Index", "Shop");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult ProductDetailsImg(DetailsImgViewModel file)
        {
            return PartialView("_ProductDetailsImg", file.BigImageSrc);
        }   
    }
}
