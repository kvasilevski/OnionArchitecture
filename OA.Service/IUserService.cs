using OA.Data;
using System.Collections.Generic;

namespace OA.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        IList<User> getUsersByFirstName(string term);
        IList<User> getUsersByAddress(string address);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }
}
