using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Utilities
{
    public static class BalanceManager
    {
        public static int SourceBalance(SwitchWalletContext _context, string WTTRN, Transactions old)
        {
            long AmountNew = 0; long AmountSettlementableNew = 0;
            var SourceBalance = _context.Balance.FirstOrDefault(r => r.WalletId == old.SourceWalletId);
            if (SourceBalance != null)
            {
                AmountNew = SourceBalance.Amount.Value;
                AmountNew -= old.Amountpayable.Value;
                SourceBalance.Amount = AmountNew;


                if (SourceBalance.AmountSettlementable != null)
                {
                    AmountSettlementableNew = SourceBalance.AmountSettlementable.Value;
                    AmountSettlementableNew -= old.Amountpayable.Value;

                    SourceBalance.AmountSettlementable = AmountSettlementableNew;
                }

                _context.SaveChanges();

                Transactions _transa = new Transactions();

                _transa.Id = 0;
                _transa.WTTN = old.WTTN;
                _transa.WTTRN = WTTRN;
                _transa.SourceWalletId = old.SourceWalletId;
                _transa.ResultStatus = 0;
                _transa.TransactionTypeUserId = old.TransactionTypeUserId;
                _transa.RegisterDate = DateTime.Now;
                _transa.Amount = old.Amount + old.EndUserWageAmount;
                _transa.Amountpayable = old.Amountpayable;
                _transa.EndUserWageAmount = old.EndUserWageAmount;
                _transa.Offer = 0;
                _transa.IsWage = 1;
                _transa.WageAmount = old.WageAmount;

                var res = _context.Transactions.Add(_transa);
                _context.SaveChanges();

                return 1;
            }
            else
                return 0;
        }
        public static int DestinationBalance(SwitchWalletContext _context, string WTTRN, Transactions old)
        {
            long AmountNew = 0; long AmountSettlementableNew = 0;
            var DestinationBalance = _context.Balance.FirstOrDefault(r => r.WalletId == old.DestinationWalletId);
            if (DestinationBalance != null)
            {
                AmountNew = DestinationBalance.Amount.Value;
                AmountNew += old.Amount.Value - old.UserWageAmount.Value;
                DestinationBalance.Amount = AmountNew;

                if (DestinationBalance.AmountSettlementable != null)
                {
                    AmountSettlementableNew = DestinationBalance.AmountSettlementable.Value;
                    AmountSettlementableNew += old.Amount.Value - old.UserWageAmount.Value;

                    DestinationBalance.AmountSettlementable = AmountSettlementableNew;
                }

                _context.SaveChanges();

                Transactions _transa = new Transactions();

                _transa.Id = 0;
                _transa.WTTN = old.WTTN;
                _transa.WTTRN = WTTRN;
                _transa.DestinationWalletId = old.DestinationWalletId;
                _transa.ResultStatus = 0;
                _transa.TransactionTypeUserId = old.TransactionTypeUserId;
                _transa.RegisterDate = DateTime.Now;
                _transa.Amount = old.Amount - old.UserWageAmount;
                _transa.UserWageAmount = old.UserWageAmount;
                _transa.Offer = 0;
                _transa.IsWage = 1;
                _transa.WageAmount = old.WageAmount;

                var res = _context.Transactions.Add(_transa);
                _context.SaveChanges();

                return 1;
            }
            else
                return 0;
        }
    }
}
