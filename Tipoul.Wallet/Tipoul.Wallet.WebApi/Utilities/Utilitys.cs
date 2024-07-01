using System.Globalization;
using System.Resources;
using Tipoul.Framework.DataAccessLayer;

namespace Tipoul.Wallet.WebApi.Utilities
{
    public static class Utilitys
    {
        public static string GetBankImages(TipoulFrameworkDbContext _tipoulframeworkdbcontext, int ? Id)
        {
            string Filename = "";
            var ObjsBank= _tipoulframeworkdbcontext.Banks.FirstOrDefault(r=>r.Id== Id);
            if (ObjsBank != null)
            {
               
                switch (ObjsBank.Code)
                {
                    case "CBI":
                        Filename = "https://wallet.tipoul.com/DynamicImages/CBI.png";
                        break;
                    case "ENB":
                        Filename = "https://wallet.tipoul.com/DynamicImages/ENB.png";
                        break;
                    case "ANS":
                        Filename = "https://wallet.tipoul.com/DynamicImages/ANS.png";
                        break;
                    case "IRZ":
                        Filename = "https://wallet.tipoul.com/DynamicImages/IRZ.png";
                        break;
                    case "IRV":
                        Filename = "https://wallet.tipoul.com/DynamicImages/IRV.png";
                        break;
                    case "AYN":
                        Filename = "https://wallet.tipoul.com/DynamicImages/AYN.png";
                        break;
                    case "PAR":
                        Filename = "https://wallet.tipoul.com/DynamicImages/PAR.png";
                        break;
                    case "PAS":
                        Filename = "https://wallet.tipoul.com/DynamicImages/PAS.png";
                        break;
                    case "TEJ":
                        Filename = "https://wallet.tipoul.com/DynamicImages/TEJ.png";
                        break;
                    case "BTT":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BTT.png";
                        break;
                    case "BTS":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BTS.png";
                        break;
                    case "HEK":
                        Filename = "https://wallet.tipoul.com/DynamicImages/HEK.png";
                        break;
                    case "KHMI":
                        Filename = "https://wallet.tipoul.com/DynamicImages/KHMI.png";
                        break;
                    case "DEY":
                        Filename = "https://wallet.tipoul.com/DynamicImages/DEY.png";
                        break;
                    case "REF":
                        Filename = "https://wallet.tipoul.com/DynamicImages/REF.png";
                        break;
                    case "SAM":
                        Filename = "https://wallet.tipoul.com/DynamicImages/SAM.png";
                        break;
                    case "BSP":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BSP.png";
                        break;
                    case "SAR":
                        Filename = "https://wallet.tipoul.com/DynamicImages/SAR.png";
                        break;
                    case "SIN":
                        Filename = "https://wallet.tipoul.com/DynamicImages/SIN.png";
                        break;
                    case "SHR":
                        Filename = "https://wallet.tipoul.com/DynamicImages/SHR.png";
                        break;
                    case "BSI":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BSI.png";
                        break;
                    case "BSM":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BSM.png";
                        break;
                    case "RES":
                        Filename = "https://wallet.tipoul.com/DynamicImages/RES.png";
                        break;
                    case "MHR":
                        Filename = "https://wallet.tipoul.com/DynamicImages/MHR.png";
                        break;
                    case "GHA":
                        Filename = "https://wallet.tipoul.com/DynamicImages/GHA.png";
                        break;
                    case "BKA":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BKA.png";
                        break;
                    case "BKV":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BKV.png";
                        break;
                    case "GAR":
                        Filename = "https://wallet.tipoul.com/DynamicImages/GAR.png";
                        break;
                    case "BMK":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BMK.png";
                        break;
                    case "MEL":
                        Filename = "https://wallet.tipoul.com/DynamicImages/MEL.png";
                        break;
                    case "BMI":
                        Filename = "https://wallet.tipoul.com/DynamicImages/BMI.png";
                        break;
                    case "NOR":
                        Filename = "https://wallet.tipoul.com/DynamicImages/NOR.png";
                        break;
                    case "PST":
                        Filename = "https://wallet.tipoul.com/DynamicImages/PST.png";
                        break;
                    case "MET":
                        Filename = "https://wallet.tipoul.com/DynamicImages/MET.png";
                        break;
                    case "ASKC":
                        Filename = "https://wallet.tipoul.com/DynamicImages/ASKC.png";
                        break;
                    case "KSAC":
                        Filename = "https://wallet.tipoul.com/DynamicImages/KSAC.png";
                        break;
                    case "MEH":
                        Filename = "https://wallet.tipoul.com/DynamicImages/MEH.png";
                        break;
                    case "TAT":
                        Filename = "https://wallet.tipoul.com/DynamicImages/TAT.png";
                        break;
                    default:
                        Filename = "";
                        break;

                }
            }
            else
                Filename = "";
            return Filename;
        }
        public static string NumberFormat(string Text)
        {
            int Length = Text.Length;
            string MyText = "";
            int i = Length - 3;
            int j = 3;
            while (Length > 3)
            {
                MyText = Text.Substring(i, j) + "," + MyText;
                i = i - 3;
                Length = Length - 3;
            }
            if (Length > 0)
                MyText = Text.Substring(0, Length) + "," + MyText;
            MyText = MyText.Substring(0, MyText.Length - 1);
            return MyText;
        }
        public static string ConvertDate(DateTime LatinTime)
        {
            try
            {
                PersianCalendar jc = new PersianCalendar();
                DateTime thisDate = LatinTime;

                string day;
                string month;
                string year;
                string newdate = "";
                day = jc.GetDayOfMonth(thisDate).ToString();
                month = jc.GetMonth(thisDate).ToString();
                year = jc.GetYear(thisDate).ToString();
                if (int.Parse(day) < 10)
                    day = "0" + day;
                if (int.Parse(month) < 10)
                    month = "0" + month;
                newdate = year + "/" + month + "/" + day;
                return newdate;
            }
            catch { return ""; }
        }
        public static string PersianDate(DateTime mydate)
        {
            string Day = mydate.DayOfWeek.ToString();
            string Month = "";
            string DateSubmit = "";
            string[] Text = ConvertDate(DateTime.Now).Split('/');

            try
            {
               
                switch (Text[1])
                {
                    case "01":
                        Month = "فروردین";
                        break;
                    case "02":
                        Month = "اردیبهشت";
                        break;
                    case "03":
                        Month = "خرداد";
                        break;
                    case "04":
                        Month = "تیر";
                        break;
                    case "05":
                        Month = "مرداد";
                        break;
                    case "06":
                        Month = "شهریور";
                        break;
                    case "07":
                        Month = "مهر";
                        break;
                    case "08":
                        Month = "آبان";
                        break;
                    case "09":
                        Month = "آذر";
                        break;
                    case "10":
                        Month = "دی";
                        break;
                    case "11":
                        Month = "بهمن";
                        break;
                    case "12":
                        Month = "اسفند";
                        break;
                    default:
                        break;
                }

                switch (Day)
                {
                    case "Sunday":
                        DateSubmit = "یک شنبه " + " " + ConvertToPersianNumber(Text[2]) + Month + ConvertToPersianNumber(Text[0]);
                        break;
                    case "Monday":
                        DateSubmit = "دو شنبه " + " " + ConvertToPersianNumber(Text[2]) + Month + ConvertToPersianNumber(Text[0]);
                        break;
                    case "Tuesday":
                        DateSubmit = "سه شنبه " + " " + ConvertToPersianNumber(Text[2]) + Month + ConvertToPersianNumber(Text[0]);
                        break;
                    case "Wednesday":
                        DateSubmit = "چهار شنبه " + " " + ConvertToPersianNumber(Text[2]) + Month + ConvertToPersianNumber(Text[0]);
                        break;
                    case "Thursday":
                        DateSubmit = "پنج شنبه " + " " + ConvertToPersianNumber(Text[2]) + Month + ConvertToPersianNumber(Text[0]);
                        break;
                    case "Friday":
                        DateSubmit = "جمعه " + " " + ConvertToPersianNumber(Text[2]) + Month + ConvertToPersianNumber(Text[0]);
                        break;
                    case "Saturday":
                        DateSubmit = "شنبه " + " " + ConvertToPersianNumber(Text[2]) + Month + ConvertToPersianNumber(Text[0]);
                        break;

                }

               
            }
            catch {  }
            return DateSubmit;
        }
        public static string ConvertToPersianNumber(string num)
        {
            string number = num.Trim();
            bool m = Array.TrueForAll<char>(number.ToCharArray(), s => char.IsDigit(s));
            char[] temp = new char[number.Length];
            if (m)
            {
                int i = 0;
                Array.ForEach<char>(number.ToCharArray(), b => { temp[i] = (char)(((int)b + 1728)); i += 1; });
                string ff = new string(temp);
                return ff;
            }
            else { return null; }
        }
    }
}
