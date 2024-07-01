
using Tipoul.Wallet.WebApi.Entity;
using Tipoul.Wallet.WebApi.Models;

namespace Tipoul.Wallet.WebApi.Infrastructure
{
    public interface IUsersRepo
    {
        User Login(string username,string Password);
        Users GetInfo(string token);
    }
}
