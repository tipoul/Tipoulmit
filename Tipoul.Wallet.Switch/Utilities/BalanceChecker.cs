using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Utilities
{
    public static class BalanceChecker
    {
        public static Boolean SourceChecker(SwitchWalletContext _context, long SourceWalletId, long Amountpayable)
        {
            var SourceBalance = _context.Balance.FirstOrDefault(r => r.WalletId == SourceWalletId);
            if (SourceBalance != null)
            {
                if (SourceBalance.Amount != null)
                {
                    if (SourceBalance.Amount >= Amountpayable)
                    {
                        if (SourceBalance.AmountSettlementable != null)
                        {
                            if (SourceBalance.AmountSettlementable >= Amountpayable)
                                return true;
                            else
                                return false;
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else return false;


                
            }
            else
                return false;
        }
        public static Boolean DestinationChecker(SwitchWalletContext _context, long DestinationWalletId, long UserWageAmount)
        {           
            var DestinationBalance = _context.Balance.FirstOrDefault(r => r.WalletId == DestinationWalletId);
            if (DestinationBalance != null)
            {
                if (DestinationBalance.Amount != null)
                {
                    if (DestinationBalance.Amount >= UserWageAmount)
                    {
                        if (DestinationBalance.AmountSettlementable != null)
                        {
                            if (DestinationBalance.AmountSettlementable >= UserWageAmount)
                                return true;
                            else
                                return false;
                        }
                        else
                            return true;
                    }
                    else
                        return false;
                }
                else
                    return false;


            }
            else
                return false;
        }
    }
}
