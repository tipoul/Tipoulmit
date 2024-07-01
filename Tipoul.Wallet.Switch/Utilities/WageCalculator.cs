using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Models;
using Tipoul.Wallet.Switch.Services;

namespace Tipoul.Wallet.Switch.Utilities
{
    public static class WageCalculator
    {
        public static Calculatemodels WageCal(SwitchWalletContext _context, long TransactionTypeUserId, long Amount)
        {
            long WageAmount = 0; long UserWageAmount = 0; long EndUserWageAmount = 0;
            Calculatemodels cm = new Calculatemodels();
            TransactionTypesRepo wre = new TransactionTypesRepo(_context);

            TransactionTypeUserRepo ttu = new TransactionTypeUserRepo(_context);
            var ObjsTU = ttu.GetById(TransactionTypeUserId);
            if (ObjsTU != null)
            {

                if ((ObjsTU.Wage * Amount) > ObjsTU.MaxWage)
                    cm.WageAmount = ObjsTU.MaxWage.Value;
                else
                    cm.WageAmount = long.Parse(Math.Round(ObjsTU.Wage.Value * Amount).ToString());


                if (ObjsTU.UserRate.Value > 0)
                {
                    UserWageAmount = long.Parse(Math.Round(((100 - ObjsTU.UserRate.Value) * cm.WageAmount) / 100).ToString());
                    cm.SourceAmount = UserWageAmount;
                }
                else
                    cm.SourceAmount = UserWageAmount;


                if (100 - ObjsTU.UserRate.Value > 0)
                {
                    EndUserWageAmount = long.Parse(Math.Round((ObjsTU.UserRate.Value * cm.WageAmount) / 100).ToString());
                    cm.DestinationAmount = EndUserWageAmount;
                }
                else
                    cm.DestinationAmount = 0;                

                return cm;
            }
            else
                return null;

        }
    }
}
