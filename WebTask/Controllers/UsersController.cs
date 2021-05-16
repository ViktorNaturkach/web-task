using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Infrastructure.Interfaces;
using WebTask.InfrastructureDTO;
using WebTask.ViewModels;
using WebTask.ViewModels.Identity.Users;

namespace WebTask.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        private readonly IRegisterService  _registerService;


        public UsersController(UserManager<User> userManager, IMapper mapper, IUsersService usersService, IRegisterService registerService)
        {
            _mapper = mapper;
            _usersService = usersService;
            _registerService = registerService;
        }

        public IActionResult Index()
        {
            var usersDTO = _usersService.GetUsers();
            var model = _mapper.Map<UsersListViewModel>(usersDTO);
            return View(model.users);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = _mapper.Map<UserDTO>(model);
                var result = await _registerService.RegisterAsync(userDTO);
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
