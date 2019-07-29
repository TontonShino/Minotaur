﻿using SharedLib;
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
            throw new NotImplementedException();
        }

        public bool Exists(string id)
        {
            return db.AppUserTokens.Any(t => t.Id == id);
        }

        public AppUserToken Get(string id)
        {
            return db.AppUserTokens.Find(id);
        }

        public AppUserToken Update(AppUserToken appUserToken)
        {
            throw new NotImplementedException();
        }
    }
}
