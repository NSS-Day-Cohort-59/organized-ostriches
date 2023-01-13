using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Security.Claims;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;
using TabloidMVC.Repositories;
using System;

namespace TabloidMVC.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public IActionResult Index()
        {
            var users = _userProfileRepository.GetAll();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            UserProfile user = _userProfileRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }
    }
}