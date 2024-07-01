using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class UsersRepo : IUsersRepo
    {
        private SwitchWalletContext _context;
        public UsersRepo(SwitchWalletContext context)
        {
            _context = context;
        }
        public Users GetById(long id)
        {
            var Users = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return Users;
        }
        public Users GetByNationalcode(string Nationalcode)
        {
            var Users = _context.Users.Where(x => x.Nationalcode == Nationalcode).FirstOrDefault();
            return Users;
        }
    }
}
