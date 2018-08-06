using Microsoft.EntityFrameworkCore;
using OA.Data;
using OA.Repo;
using OA.Repo.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace OA.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRepository<UserProfile> _userProfileRepository;

        public UserService(IUserRepository userRepository, IRepository<UserProfile> userProfileRepository)
        {
            _userRepository = userRepository;
            _userProfileRepository = userProfileRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(long id)
        {
            return _userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            _userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            UserProfile userProfile = _userProfileRepository.Get(id);
            _userProfileRepository.Remove(userProfile);
            User user = GetUser(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }

        public IList<User> getUsersByFirstName(string term)
        {
            var xxx = _userRepository.GetMany(x => x.IPAddress == "192.168.100.100");
            return _userRepository
                .AsQueryable()
                .Include(x => x.UserProfile)
                .Where(x => x.UserProfile.FirstName.ToLower().Contains(term.ToLower()))
                .ToList();
        }

        public IList<User> getUsersByAddress(string address)
        {
            return _userRepository.GetUserByAddress(address);
        }
    }
}
