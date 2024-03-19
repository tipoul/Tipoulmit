using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Tipoul.Framework.StorageModels
{
    public class UserWageTypeHistory
    {
        public UserWageTypeHistory()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public UserWageType WageType { get; set; }

        public int? StaticAmount { get; set; }

        public int? RelativeAmount { get; set; }

        public int? MaxRelativeAmount { get; set; }
        public double QuickSettlementWagePercent { get; set; }
        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public enum UserWageType
        {
            FromSettlement = 1,
            FromTransaction = 2,
            FromTransactionStaticAmount = 3,
            //Subscription = 4,
            //FreeBaseOnSettlement = 5,
            Free = 6
        }

        public static List<UserWageType> GetAllWageTypes()
        {
            return Enum.GetValues(typeof(UserWageType)).Cast<UserWageType>().ToList();
        }

        public static string GetUserTypeName(UserWageType wageType)
        {
            switch (wageType)
            {
                case UserWageType.FromSettlement:
                    return "کارمزد از تسویه";
                case UserWageType.FromTransaction:
                    return "کارمزد از تراکنش";
                case UserWageType.FromTransactionStaticAmount:
                    return "کارمزد از تراکنش به مبلغ ثابت";
                //case UserWageType.Subscription:
                //    return "خرید اشتراک";
                //case UserWageType.FreeBaseOnSettlement:
                //    return "رایگان با شرایط تسویه";
                case UserWageType.Free:
                    return "رایگان";
                default:
                    throw new InvalidEnumArgumentException(nameof(wageType));
            }
        }
    }
}
