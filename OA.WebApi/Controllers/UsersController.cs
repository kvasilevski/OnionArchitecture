using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.WebApi.Models;

namespace OA.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;

        public UsersController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
        }

        // GET: api/Users
        [HttpGet]
        public IList<UserViewModel> Get()
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

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public UserViewModel Get(int id)
        {
            var user = _userService.GetUser(id);
            var userProfile = _userProfileService.GetUserProfile(id);
            UserViewModel model = new UserViewModel
            {
                Id = user.Id,
                Name = $"{userProfile.FirstName} {userProfile.LastName}",
                Email = user.Email,
                Address = userProfile.Address
            };

            return model;
        }

        [HttpGet("{term}/term", Name = "GetByTerm")]
        public List<UserViewModel> GetByTerm(string term)
        {
            List<UserViewModel> models = new List<UserViewModel>();
            _userService.getUsersByFirstName(term).ToList().ForEach(u =>
            {
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{u.UserProfile.FirstName} {u.UserProfile.LastName}",
                    Email = u.Email,
                    Address = u.UserProfile.Address
                };
                models.Add(user);
            });

            return models;
        }

        [HttpGet("{address}/address", Name = "GetByAddress")]
        public List<UserViewModel> GetByAddress(string address)
        {
            List<UserViewModel> models = new List<UserViewModel>();
            _userService.getUsersByAddress(address).ToList().ForEach(u =>
            {
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{u.UserProfile.FirstName} {u.UserProfile.LastName}",
                    Email = u.Email,
                    Address = u.UserProfile.Address
                };
                models.Add(user);
            });

            return models;
        }


        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
