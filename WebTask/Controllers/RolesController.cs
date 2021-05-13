using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.EFData.Entities;
using WebTask.Services.DTO;
using WebTask.Services.Interfaces;
using WebTask.Services.Interfaces.Identity;
using WebTask.ViewModels;
using WebTask.ViewModels.Identity.Users;

namespace WebTask.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class RolesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IRoleService _roleService;
        private readonly IUsersService _usersService;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IMapper mapper, IRoleService roleService, IUsersService usersService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _roleService = roleService;
            _usersService = usersService;
        }
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
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
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {
            var usersDTO = _usersService.GetUsers();
            var model = _mapper.Map<UsersListViewModel>(usersDTO);
            return View(model.users);
        }

        public async Task<IActionResult> Edit(string userId)
        {
            ChangeRoleDTO user = await _roleService.GetUserRoles(userId);
            if (user == null)
            {
                return NotFound();
            }
            ChangeRoleViewModel model = _mapper.Map<ChangeRoleViewModel>(user);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var result = await _roleService.EditUserRoles(userId,roles);
            if (result)
            {
                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
