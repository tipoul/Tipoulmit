using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;
using Tipoul.Wallet.WebApi.Data;
using Tipoul.Wallet.WebApi.Entity;
using Tipoul.Wallet.WebApi.Infrastructure;
using Tipoul.Wallet.WebApi.Models;
using Tipoul.Wallet.WebApi.Utilities;

namespace Tipoul.Wallet.WebApi.Services
{

    public class UsersRepo : IUsersRepo
    {

        private WalletWebApiContext _context;
        public UsersRepo(WalletWebApiContext context)
        {
            _context = context;
        }

        public User Login(string username, string Password)
        {
            var NewPassword = StringUtility.Zip(JsonSerializer.Serialize(Password));

            try
            {
                var entry = _context.Users.Where(x => x.Username == username && x.Password == NewPassword).FirstOrDefault();
                if (entry != null)       
                    return new User { FirtName = entry.Name, LastName = entry.Lastname, Token = entry.Token ,Id=entry.Id};  
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Users GetInfo(string token)
        {

            try
            {
                var entry = _context.Users.Where(x => x.Token == token).FirstOrDefault();
                if (entry != null)
                    return entry;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
