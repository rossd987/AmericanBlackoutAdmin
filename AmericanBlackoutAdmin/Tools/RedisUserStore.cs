using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using AmericanBlackoutAdmin.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using AmericanBlackout.Domain.Redis;

namespace AmericanBlackoutAdmin.Tools
{
    public class RedisUserStore<TUser> : IUserStore<TUser>, IUserPasswordStore<TUser> where TUser:IdentityUser
    {
        public System.Threading.Tasks.Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<TUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<TUser> FindByNameAsync(string userName)
        {
            var redis = new ABRedisClient();

            var client = redis.Create();

            var user = client.As<ApplicationUser>().GetAll().Where(x => x.UserName == userName);

            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public System.Threading.Tasks.Task<string> GetPasswordHashAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> HasPasswordAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        //public System.Threading.Tasks.Task CreateAsync(TUser user)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Threading.Tasks.Task DeleteAsync(TUser user)
        //{
        //    throw new NotImplementedException();
        //}

        //System.Threading.Tasks.Task<TUser> IUserStore<TUser>.FindByIdAsync(string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //System.Threading.Tasks.Task<TUser> IUserStore<TUser>.FindByNameAsync(string userName)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Threading.Tasks.Task UpdateAsync(TUser user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}