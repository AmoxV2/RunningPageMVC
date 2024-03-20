﻿
using Learning_MVC.Interfaces;
using Learning_MVC.Models;
using Learning_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Learning_MVC.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
             _userRepository= userRepository;
        }
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach(var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                };
                result.Add(userViewModel);
            }
            return View(result);
        }
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository .GetUserById(id);
            var UserDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,   
                Pace = user.Pace,
                Mileage = user.Mileage,
            };
            return View(UserDetailViewModel);
        }

    }
}
