using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;

namespace Tipoul.CoreBanking.Switch
{
    public class UtilitySwitch
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccessDB FindAccessDatabse(IUnitOfWork _unitOfWork)
        {
            var services = _unitOfWork.SourcesRepo.GetByActive();
            if (services != null)
            {
                AccessDB cccessdb = new AccessDB();
                cccessdb.UserName = services.Username;
                cccessdb.Password = services.Password;

                return cccessdb;
            }
            else
                return null;
        }
        public int FindBanks(IUnitOfWork _unitOfWork,string bankcode)
        {
            var services = _unitOfWork.BanksRepo.GetByCode(bankcode);
            if (services != null)            
              return  services.Id;
            
            else
                return 0;
        }
        public Source FindSource(IUnitOfWork _unitOfWork)
        {
            var services = _unitOfWork.SourcesRepo.GetByActive();
            if (services != null)
                return services;

            else
                return null;
        }
    }
     
}
