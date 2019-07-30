using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinotaur.Data;

namespace WebMinotaur.Repositories
{
    public class AppUserTokensRepository : IAppUserTokensRepository
    {
        private readonly ApplicationDbContext db;
        public AppUserTokensRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public AppUserToken Create(AppUserToken appUserToken)
        {
            db.AppUserTokens.Add(appUserToken);
            db.SaveChanges();
            return appUserToken;
        }

        public void Delete(string id)
        {
            var token = db.AppUserTokens.Find(id);
            db.AppUserTokens.Remove(token);
            db.SaveChanges();
        }

        public bool Exists(string id)
        {
            return db.AppUserTokens.Any(t => t.Id == id);
        }

        public AppUserToken Get(string id)
        {
            return db.AppUserTokens.Find(id);
        }

        public List<AppUserToken> GetAllByUserId(string userId)
        {
            return db.AppUserTokens.Where(u => u.AppUserId == userId).ToList();
        }

        public async Task<List<AppUserToken>> GetAllByUserIdAsync(string userId)
        {
            return await db.AppUserTokens.Where(u => u.AppUserId == userId).ToListAsync();
        }

        public AppUserToken Update(AppUserToken appUserToken)
        {
            throw new NotImplementedException();
        }
    }
}
