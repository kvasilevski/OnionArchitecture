using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace OA.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public List<UserViewModel> Index()
        {
            List<UserViewModel> models = new List<UserViewModel>();
            _userService.GetUsers().ToList().ForEach(u =>
            {
                var userProfile = _userProfileService.GetUserProfile(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address
                };
                models.Add(user);
            });

            return models;
        }
    }
}