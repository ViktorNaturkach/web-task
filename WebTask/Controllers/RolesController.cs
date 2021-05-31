using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Infrastructure.Interfaces;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.InfrastructureDTO.DTO.Identity;
using WebTask.ViewModels.Identity.Roles;

namespace WebTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        public RolesController(IMapper mapper, IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var rolesDTO = _roleService.GetIdentityRoles();
            var model = _mapper.Map<IEnumerable<RoleViewModel>>(rolesDTO);
            return View(model);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleDTO = _mapper.Map<RoleDTO>(model);
                var result = await _roleService.CreateRoleAsync(roleDTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
