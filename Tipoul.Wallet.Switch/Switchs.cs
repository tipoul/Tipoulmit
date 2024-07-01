using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Services;

namespace Tipoul.Wallet.Switch
{
    public class Switchs
    {       
        public long calculate(SwitchWalletContext _switchwalletcontext, int SourceWalletNo, long Amount, double WageAmount)
        {
            //TransactionTypesRepo wre = new TransactionTypesRepo(_switchwalletcontext);
            //long TransactionTypeId = wre.GetByTitle("", false);
            //if (TransactionTypeId > 0)
            //{
            //    TransactionTypeUserRepo ttu = new TransactionTypeUserRepo(_context);
            //    var ObjsTransactionTypeUser = ttu.GetByTypeUser(TransactionTypeId, DestinationUserId);
            //    if (ObjsTransactionTypeUser != null)
            //    {

            //        if ((ObjsTransactionTypeUser.Wage * Amount) > ObjsTransactionTypeUser.MaxWage)
            //            return ObjsTransactionTypeUser.MaxWage.Value;
            //        else
            //            return ObjsTransactionTypeUser.Wage.Value * Amount;

            //    }
            //    else
            //        return 0;
            //}
            //else
                return 0;
        }
    }
}
