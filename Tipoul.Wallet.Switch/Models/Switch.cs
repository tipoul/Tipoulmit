using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Numerics;
using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Infrastructure;
using Tipoul.Wallet.Switch.Services;

namespace Tipoul.Wallet.Switch.Models
{
   
    public class Switch
    {
       
        public Switch(IUnitOfWork unitOfWork, long WalletId,long TransactionTypeId,long Amount)
        {
            var ObjTransactionTypeUser = unitOfWork.TransactionTypeUserRepo.GetById(TransactionTypeId);
            if(ObjTransactionTypeUser != null)
            {
                //Boolean BalanceEffect= ObjTransactionTypeUser.TransactionTypes.BalanceEffect;
                //long BalanceTypeId= ObjTransactionTypeUser.TransactionTypes.BalanceTypeId.Value;

                //var ObjBalance = unitOfWork.BalanceRepo.GetByBalance(BalanceTypeId, WalletId);
                //if (ObjBalance != null)
                //{
                //    long BalanceId = ObjBalance.Id;
                //    if(BalanceEffect)
                //    {
                //        //ObjBalance.Amount += Amount;
                //        //ObjBalance.AmountSettlementable += Amount;

                //        unitOfWork.TransactionTypeUserRepo.GetById(TransactionTypeId);
                //    }

                //}
                //else
                //{

                //}
            }

        }
    }
}
