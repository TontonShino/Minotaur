using SharedLib;
using SharedLib.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinotaur.Data;

namespace WebMinotaur.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext db;
        public AppUserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public AppUser Get(string id)
        {
            return db.AppUsers.FirstOrDefault(u => u.Id == id);
        }

        public AppUser GetByUsername(string username)
        {
            return db.AppUsers.FirstOrDefault(u => u.UserName == username);
        }
    }
}
