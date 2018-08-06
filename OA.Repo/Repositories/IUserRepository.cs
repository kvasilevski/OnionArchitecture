using OA.Data;
using System.Collections.Generic;

namespace OA.Repo.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IList<User> GetUserByAddress(string address);
    }
}
