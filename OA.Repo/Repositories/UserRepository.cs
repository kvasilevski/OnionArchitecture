using Microsoft.EntityFrameworkCore;
using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OA.Repo.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<User> GetUserByAddress(string address)
        {
            var list = dbSet.Include(x => x.UserProfile).Where(x => x.UserProfile.Address.ToLower() == address).ToList();
            return list;
        }
    }
}
