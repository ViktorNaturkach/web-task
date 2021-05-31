using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Infrastructure.Interfaces;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.InfrastructureDTO;
using WebTask.ViewModels;
using WebTask.ViewModels.Identity.Users;

namespace WebTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        private readonly IRoleService _roleService;
            public UsersController(IMapper mapper, IUsersService usersService, IRoleService roleService)
        {
            _mapper = mapper;
            _usersService = usersService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var usersDTO = await _usersService.GetUsers();
            var model = _mapper.Map<IEnumerable<UserViewModel>>(usersDTO);
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateUserViewModel();
            model.Roles =  _roleService.GetIdentityRoles().Select(x => x.Name).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = _mapper.Map<UserDTO>(model);
                var result = await _usersService.CreateUserAsync(userDTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Users");
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

        public async Task<IActionResult> Edit(string id)
        {
            UserDTO user = await _usersService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = _mapper.Map<EditUserViewModel>(user);
            model.AllRoles = _roleService.GetIdentityRoles().Select(x => x.Name).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = _mapper.Map<UserDTO>(model);
                var result = await _usersService.UpdateUserAsync(userDTO);
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
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _usersService.DeleteUserAsync(id);
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
