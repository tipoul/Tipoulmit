using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token;
using Tipoul.Framework.Services.OpenBanking.Shahin.Services;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;

using Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts;
using Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models;
using Microsoft.IdentityModel.Tokens;
using Tipoul.CoreBanking.Services.KYC.OutModel.Iban;
using Tipoul.CoreBanking.Services.KYC.Card.Inquiry;
using Tipoul.CoreBanking.Services.KYC.OutModel.Cart;
using Azure.Core;
using Tipoul.Framework.Services.OpenBanking.Shahin.Public.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Public;
using Tipoul.CoreBanking.Services.KYC.NationalCode.Inquiry;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Models;
using System.Text.RegularExpressions;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account;
using static Tipoul.CoreBanking.Services.KYC.OutModel.Iban.OutIban;
using static Tipoul.CoreBanking.Services.KYC.OutModel.Cart.Outowner;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models;
using Microsoft.VisualBasic;
using System.Net.WebSockets;

namespace Tipoul.CoreBanking.Switch
{
    public class Convert
    {
        private string TokenUrl;
        private string ApiUrl;
        private string UserName;
        private string Password;

        private IUnitOfWork _unitOfWork;

        public void UtilityConvert(string tokenurl, string apiurl, string username, string password, IUnitOfWork unitOfWork)
        {
            TokenUrl = tokenurl;
            ApiUrl = apiurl;
            UserName = username;
            Password = password;
            _unitOfWork = unitOfWork;
        }
        public string Accountnumbertype(string Accountnumtype)
        {
            if (Accountnumtype.Length >= 9 && Accountnumtype.Length <= 13)
                return "AccountNumber";
            else
            {
                if (Accountnumtype.Length == 16)
                    return "CardNumber";
                else
                {
                    if (Accountnumtype.Length == 26)
                        return "Iban";
                    else
                        return "Wrong Format";
                }
            }
        }
        public Boolean ShahinGetIbanLimit(string BankCode)
        {
            string[] ArrayBanks = { "AYN", "DEY", "PAS", "ENB", "TEJ", "BTS", "BSI", "SAM", "BSP", "SAR", "SIN", "BSM", "BKA", "BKV", "BMK", "MEL", "BMI", "NOR" };

            if (ArrayBanks.Contains(BankCode))
                return true;
            else
                return false;

        }

        public async Task<OutIban.OutModelIban> ShahinGetIbanOperation(string? BankCode, string Account, string Type)
        {
            string Iban = ""; string tokenResultdata = ""; string tokenUsername = "";
            UtilitySwitch utility = new UtilitySwitch();

            OutIban.OutModelIban om = new OutIban.OutModelIban();
            OutIban.ResultObjectIban rob = new OutIban.ResultObjectIban();


            int BankId = utility.FindBanks(_unitOfWork, BankCode);

            Source source = utility.FindSource(_unitOfWork);
            if (source != null)
            {

                if (Type == "CardNumber")
                {
                    GetToken gt = new GetToken();
                    Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);

                    Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos _i = new Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos();

                    _i.bank = tokenResult.bank;
                    _i.nationalCode = tokenResult.user_name;
                    _i.sourceAccount = source.AccountNo;
                    _i.cardNumber = Account;

                    tokenResultdata = tokenResult.access_token;
                    tokenUsername = tokenResult.user_name;

                    GeCarts m = new GeCarts();
                    Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfoResult cardInfoResult = await m.GetCardInfo(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");

                    Iban = cardInfoResult.respObject.iban;
                }
                else
                {
                    if (Type == "AccountNumber")
                    {
                        GetToken gt = new GetToken();
                        Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);

                        Iban _i = new Iban();
                        _i.bank = BankCode;
                        _i.nationalCode = tokenResult.user_name;
                        _i.sourceAccount = Account;


                        tokenResultdata = tokenResult.access_token;
                        tokenUsername = tokenResult.user_name;

                        GetIban m = new GetIban();
                        Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models.IbanResult ibanInfoResults = await m.GetIbans(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");

                        Iban = ibanInfoResults.respObject.ibanNumber;

                    }
                    else
                    {
                        GetToken gt = new GetToken();
                        Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);

                        tokenResultdata = tokenResult.access_token;
                        tokenUsername = tokenResult.user_name;

                        Iban = Account;
                    }
                }


                IbanInfo _iif = new IbanInfo();
                _iif.bank = "BSI";
                _iif.nationalCode = tokenUsername;
                _iif.sourceAccount = Iban;

                GetIbanInfo mif = new GetIbanInfo();
                Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models.IbanInfoResult ibanInfoResult = await mif.GetIbanInfos(_iif, ApiUrl, UserName, Password, tokenResultdata, "");

                Ibans IDB = new Ibans();


                BankCode = ibanInfoResult.respObject.bank;
                BankId = utility.FindBanks(_unitOfWork, BankCode);
                if (BankId > 0)
                {
                    IDB.BankId = BankId;
                    IDB.SourceId = source.Id;
                    IDB.DestinationAccount = Iban;
                    IDB.DestinationAccountType = 1;

                    _unitOfWork.IbansRepo.Insert(IDB);
                    _unitOfWork.Save();


                    om.message = "عملیات با موفقیت انجام شد";
                    Random rnd = new Random();
                    int numberrandom = rnd.Next(100000, 999999);
                    rob.ibanNumber = Iban;

                    rob.firstName = ibanInfoResult.respObject.firstName;
                    rob.lastName = ibanInfoResult.respObject.lastName;
                    rob.accountNumber = ibanInfoResult.respObject.accountNumber;
                    rob.ibanNumber = ibanInfoResult.respObject.ibanNumber;
                    rob.bank = ibanInfoResult.respObject.bank;
                    rob.accountStatus = ibanInfoResult.respObject.accountStatus;
                    rob.nationalCode = ibanInfoResult.respObject.nationalCode;

                    om.messagecode = "10000";
                    om.statuscode = "200";
                    om.resultobject = rob;
                    om.tracenumber = numberrandom;
                    om.trakingnumber = "";
                }
                else
                {
                    Random rnd = new Random();
                    int numberrandom = rnd.Next(100000, 999999);
                    rob.ibanNumber = "";
                    om.message = "سیستم پاسخ گو نیست";
                    om.messagecode = "10007";
                    om.statuscode = "200";
                    om.resultobject = rob;
                    om.tracenumber = numberrandom;
                    om.trakingnumber = "";
                }
            }
            else
            {
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                rob.ibanNumber = "";
                om.message = "سیستم پاسخ گو نیست";
                om.messagecode = "10007";
                om.statuscode = "200";
                om.resultobject = rob;
                om.tracenumber = numberrandom;
                om.trakingnumber = "";
            }

            return om;
        }
        public async Task<Outowner.OutModelCart> ShahinGetOwnerCartInfoOperation(string Account)
        {
            UtilitySwitch utility = new UtilitySwitch();

            Outowner.OutModelCart ow = new Outowner.OutModelCart();
            Outowner.ResultObjectCart rob = new Outowner.ResultObjectCart();

            Source source = utility.FindSource(_unitOfWork);
            if (source != null)
            {
                GetToken gt = new GetToken();
                Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);


                Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos _i = new Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos();

                _i.bank = tokenResult.bank;
                _i.nationalCode = tokenResult.user_name;
                _i.sourceAccount = source.AccountNo;
                _i.cardNumber = Account;

                GeCarts m = new GeCarts();
                Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfoResult cardInfoResult = await m.GetCardInfo(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");

                string BankCode = cardInfoResult.respObject.bank;
                int BankId = utility.FindBanks(_unitOfWork, BankCode);
                if (BankId > 0)
                {
                    Tipoul.Framework.Services.OpenBanking.Shahin.Entity.CardInfos IDB = new Tipoul.Framework.Services.OpenBanking.Shahin.Entity.CardInfos();

                    IDB.BankId = BankId;
                    IDB.SourceId = source.Id;
                    IDB.DestinationAccount = cardInfoResult.respObject.iban;
                    IDB.DestinationAccountType = 1;

                    _unitOfWork.CardInfosRepo.Insert(IDB);
                    _unitOfWork.Save();



                    ow.message = "عملیات با موفقیت انجام شد";
                    Random rnd = new Random();
                    int numberrandom = rnd.Next(100000, 999999);

                    rob.iban = cardInfoResult.respObject.iban;
                    rob.ownerName = cardInfoResult.respObject.ownerName;
                    rob.accountNumber = cardInfoResult.respObject.accountNumber;
                    rob.bank = cardInfoResult.respObject.bank;

                    ow.messagecode = "10000";
                    ow.statuscode = "200";
                    ow.resultobject = rob;
                    ow.tracenumber = numberrandom;
                    ow.trakingnumber = "";


                }
                else
                {
                    Random rnd = new Random();
                    int numberrandom = rnd.Next(100000, 999999);
                    rob.iban = "";
                    ow.message = "سیستم پاسخ گو نیست";
                    ow.messagecode = "10007";
                    ow.statuscode = "200";
                    ow.resultobject = rob;
                    ow.tracenumber = numberrandom;
                    ow.trakingnumber = "";
                }


            }
            else
            {
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                rob.iban = "";
                ow.message = "سیستم پاسخ گو نیست";
                ow.messagecode = "10007";
                ow.statuscode = "200";
                ow.resultobject = rob;
                ow.tracenumber = numberrandom;
                ow.trakingnumber = "";
            }

            return ow;
        }
        public async Task<OutNationalIdentity.OutModelNationalIdentity> ShahinGetnationalCode(string nationalCode, string iban, string birthDate, string? BankCode, string Type)
        {

            string Iban = iban; string tokenResultdata = ""; string tokenUsername = "";
            UtilitySwitch utility = new UtilitySwitch();

            OutNationalIdentity.OutModelNationalIdentity owf = new OutNationalIdentity.OutModelNationalIdentity();
            OutNationalIdentity.ResultObjectNationalIdentity robf = new OutNationalIdentity.ResultObjectNationalIdentity();

            OutIban.OutModelIban om = new OutIban.OutModelIban();
            OutIban.ResultObjectIban rob = new OutIban.ResultObjectIban();


            int BankId = utility.FindBanks(_unitOfWork, BankCode);
            Source source = utility.FindSource(_unitOfWork);

            Random rnd = new Random();
            int numberrandom = rnd.Next(100000, 999999);

            GetToken gt = new GetToken();
            Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);

            tokenResultdata = tokenResult.access_token;
            tokenUsername = tokenResult.user_name;

            if (source != null)
            {
                if (Type == "CardNumber")
                {

                    Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos _i = new Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos();

                    _i.bank = tokenResult.bank;
                    _i.nationalCode = tokenResult.user_name;
                    _i.sourceAccount = source.AccountNo;
                    _i.cardNumber = iban;

                   

                    GeCarts m = new GeCarts();
                    Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfoResult cardInfoResult = await m.GetCardInfo(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");

                    Iban = cardInfoResult.respObject.iban;

                    return await reult(nationalCode, Iban, birthDate, tokenResultdata, tokenUsername);

                }
                else
                {
                    if (Type == "AccountNumber")
                    {
                        Iban _i = new Iban();
                        _i.bank = BankCode;
                        _i.nationalCode = tokenResult.user_name;
                        _i.sourceAccount = iban;
                                             

                        GetIban m = new GetIban();
                        Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models.IbanResult ibanInfoResults = await m.GetIbans(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");

                        Iban = ibanInfoResults.respObject.ibanNumber;
                        return await reult(nationalCode, Iban, birthDate, tokenResultdata, tokenUsername);


                    }
                    else
                    {
                        return await reult(nationalCode, Iban, birthDate, tokenResultdata, tokenUsername);
                    }
                }
            }
            else
            {

                robf.ibanNumber = "";
                robf.firstName = "";
                robf.lastName = "";
                robf.bank = "";
                robf.ibanCheckResult = "";
                robf.nationalCode = nationalCode;
                robf.accountNumber = iban;
                owf.message = "سیستم پاسخ گو نیست";
                owf.messagecode = "10004";
                owf.statuscode = "200";
                owf.resultobject = robf;
                owf.tracenumber = numberrandom;
                owf.trakingnumber = "";

                return owf;

            }

        }
        public async Task<OutIban.ResultObjectIban> GetComplateInfo(IbanInfo _iif, string ApiUrl, string UserName, string Password, string tokenResultdata)
        {
            OutIban.ResultObjectIban rob = new OutIban.ResultObjectIban();
            GetIbanInfo mif = new GetIbanInfo();

            Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models.IbanInfoResult ibanInfoResult = await mif.GetIbanInfos(_iif, ApiUrl, UserName, Password, tokenResultdata, "");

            rob.firstName = ibanInfoResult.respObject.firstName;
            rob.lastName = ibanInfoResult.respObject.lastName;
            rob.accountNumber = ibanInfoResult.respObject.accountNumber;
            rob.ibanNumber = ibanInfoResult.respObject.ibanNumber;
            rob.bank = ibanInfoResult.respObject.bank;
            rob.accountStatus = ibanInfoResult.respObject.accountStatus;
            rob.nationalCode = ibanInfoResult.respObject.nationalCode;

            return rob;
        }

        public async Task<OutNationalIdentity.OutModelNationalIdentity> reult(string nationalCode, string Iban, string birthDate, string Token, string tokenUsername)
        {
            OutNationalIdentity.OutModelNationalIdentity owf = new OutNationalIdentity.OutModelNationalIdentity();
            OutNationalIdentity.ResultObjectNationalIdentity robf = new OutNationalIdentity.ResultObjectNationalIdentity();
            Random rnd = new Random();
            int numberrandom = rnd.Next(100000, 999999);

            Ibannationalcode _id = new Ibannationalcode();
            _id.nationalCode = nationalCode;
            _id.birthDate = birthDate;
            _id.iban = Iban;

            GetIbannationalcode md = new GetIbannationalcode();
            Framework.Services.OpenBanking.Shahin.Public.Models.IbannationalcodeResult ibannationalcodeResult = await md.GetIbans(_id, ApiUrl, UserName, Password, Token, "");

            owf.message = "عملیات با موفقیت انجام شد";


            IbanInfo _iifr = new IbanInfo();
            _iifr.bank = "BSI";
            _iifr.nationalCode = tokenUsername;
            _iifr.sourceAccount = Iban;

            var result1 = await GetComplateInfo(_iifr, ApiUrl, UserName, Password, Token);

            robf.ibanCheckResult = ibannationalcodeResult.respObject.ibanCheckResult;
            robf.bank = result1.bank;
            robf.firstName = result1.firstName;
            robf.lastName = result1.lastName;
            robf.accountNumber = result1.accountNumber;
            robf.accountStatus = result1.accountStatus;
            robf.ibanNumber = Iban;
            robf.nationalCode = nationalCode;

            owf.messagecode = "10000";
            owf.statuscode = "200";
            owf.resultobject = robf;
            owf.tracenumber = numberrandom;
            owf.trakingnumber = "";

            return owf;
        }

        public async Task<OutNationalInquiry.OutModelNationalInquiry> ShahinGetNationalInfoOperation(string nationalCode, string birthDate, string BankCode)
        {
            UtilitySwitch utility = new UtilitySwitch();

            OutNationalInquiry.OutModelNationalInquiry ow = new OutNationalInquiry.OutModelNationalInquiry();
            OutNationalInquiry.ResultObjectModelNationalInquiry rob = new OutNationalInquiry.ResultObjectModelNationalInquiry();

            Random rnd = new Random();
            int numberrandom = rnd.Next(100000, 999999);

            Source source = utility.FindSource(_unitOfWork);
            if (source != null)
            {
                GetToken gt = new GetToken();
                Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);


                NationalIdentity _is = new NationalIdentity();
                _is.nationalCode = nationalCode;
                _is.birthDate = birthDate;


                GetNationalIdentity ms = new GetNationalIdentity();
                Framework.Services.OpenBanking.Shahin.Public.Models.NationalIdentityResult nationalIdentityResult = await ms.GetIbans(_is, ApiUrl, UserName, Password, tokenResult.access_token, "");



                int BankId = utility.FindBanks(_unitOfWork, BankCode);
                if (BankId > 0)
                {
                    /*Tipoul.Framework.Services.OpenBanking.Shahin.Entity.CardInfos IDB = new Tipoul.Framework.Services.OpenBanking.Shahin.Entity.CardInfos();

                    IDB.BankId = BankId;
                    IDB.SourceId = source.Id;
                    IDB.DestinationAccount = cardInfoResult.respObject.iban;
                    IDB.DestinationAccountType = 1;

                    _unitOfWork.CardInfosRepo.Insert(IDB);
                    _unitOfWork.Save();*/



                    ow.message = "عملیات با موفقیت انجام شد";


                    rob.fatherName = nationalIdentityResult.respObject.fatherName;
                    rob.firstName = nationalIdentityResult.respObject.firstName;
                    rob.lastName = nationalIdentityResult.respObject.lastName;
                    rob.Birthdate = nationalIdentityResult.respObject.Birthdate;
                    rob.alive = nationalIdentityResult.respObject.alive;
                    rob.nationalCode = nationalIdentityResult.respObject.nationalCode;


                    ow.messagecode = "10000";
                    ow.statuscode = "200";
                    ow.resultobject = rob;
                    ow.tracenumber = numberrandom;
                    ow.trakingnumber = "";


                }
                else
                {

                    ow.message = "سیستم پاسخ گو نیست";

                    rob.fatherName = "";
                    rob.lastName = "";
                    rob.Birthdate = "";
                    rob.alive = false;
                    rob.nationalCode = "";


                    ow.messagecode = "10007";
                    ow.statuscode = "200";
                    ow.resultobject = rob;
                    ow.tracenumber = numberrandom;
                    ow.trakingnumber = "";
                }


            }
            else
            {

                ow.message = "سیستم پاسخ گو نیست";
                ow.messagecode = "10007";
                ow.statuscode = "200";
                rob.fatherName = "";
                rob.lastName = "";
                rob.Birthdate = "";
                rob.alive = false;
                rob.nationalCode = "";
                ow.tracenumber = numberrandom;
                ow.trakingnumber = "";
            }

            return ow;
        }
        public async Task<OutTransfer.OutModelTransfer> ShahinTransfer(string destinationAccountNumber, string destinationBank, string? destinationAccountName, long amount, long userid, TransferTypeEnum transferType, BabatEnum babat, string withdrawDescription, string paymentID, string? depositDescription, string Type)
        {           
            UtilitySwitch utility = new UtilitySwitch();

            OutTransfer.OutModelTransfer omt = new OutTransfer.OutModelTransfer();
            OutTransfer.ResultObjectTransfer rot = new OutTransfer.ResultObjectTransfer();

            int BankId = utility.FindBanks(_unitOfWork, destinationBank);
            Source source = utility.FindSource(_unitOfWork);



            GetToken gt = new GetToken();
            Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);

            if (source != null)
            {
                if (amount <= 1000)
                   return ShowResultTransfer("", "", amount, "", "", "", "", "مبلغ تسویه را وارد کنید", "10030", "200", "");

                if (depositDescription == null || depositDescription == "")
                    return ShowResultTransfer("", "", amount, "", "", "", "", "شرح برداشت را وارد کنید", "10031", "200", "");


                if (Type == "CardNumber")
                {
                    string ibanFormats = "^[0-9]{16}";
                    if (!Regex.IsMatch(destinationAccountNumber, ibanFormats))
                        return ShowResultTransfer("", "", amount, "", "", "", "", "حساب مقصد معتبر نمی باشد", "10032", "200", "");

                }
                else
                {
                    if (Type == "Iban")
                    {
                        string ibanFormat = "^IR[0-9]{24}";
                        if (!Regex.IsMatch(destinationAccountNumber, ibanFormat))
                        {
                            return ShowResultTransfer("", "", amount, "", "", "", "", "حساب مقصد معتبر نمی باشد", "10032", "200", "");
                        }

                    }

                    if (transferType == TransferTypeEnum.SATNA && destinationAccountName == null)
                    {
                        var result = await GetCartNumber(ApiUrl, UserName, Password, tokenResult.access_token, tokenResult.bank, tokenResult.user_name, tokenResult.accounts[0], destinationAccountNumber);

                        destinationAccountName = result.ownerName;
                    }

                    if (destinationAccountName == null)
                        destinationAccountName = "";

                    if (transferType == TransferTypeEnum.LOCAL && (destinationBank != "BSI" && destinationBank != "BTS"))
                        return ShowResultTransfer("", "", amount, "", "", "", "", "امکان انتقال حساب به حساب به بانک مقصد میسر نیست", "10031", "200", "");


                    if (transferType == TransferTypeEnum.SATNA && (amount < 500000000))
                        return ShowResultTransfer("", "", amount, "", "", "", "", "امکان انتقال مبلغ کمتر از 50 میلیون تومان به روش ساتنا میسر نیست", "10031", "200", "");
                }



                long accountbalanseamout = await GetAccountBalance(ApiUrl, UserName, Password, tokenResult.access_token, tokenResult.bank, tokenResult.user_name, tokenResult.accounts[0]);


                if (accountbalanseamout < amount)
                    return ShowResultTransfer("", "", amount, "", "", "", "", "موجودی حساب از مبلغ انتقال کمتر می باشد", "10031", "200", "");

                var resultibaninfo = await GetIbanInfo(ApiUrl, UserName, Password, tokenResult.access_token, tokenResult.bank, tokenResult.user_name, destinationAccountNumber);

                if (resultibaninfo.respObject.errorCode != null)
                    return ShowResultTransfer("", "", amount, "", "", "", "", "سرویس استعلام شبا در دسترس نیست", "10031", "200", "");

                else if (resultibaninfo.respObject.firstName + " " + resultibaninfo.respObject.lastName != destinationAccountName)
                    return ShowResultTransfer("", "", amount, "", "", "", "", "صاحب حساب شماره شبای مقصد وارد شده با اطلاعات استعلام شده همخوانی ندارد", "10031", "200", "");



                //var data = dbContext.Wallets.Where(f => f.UserId == userid).FirstOrDefault();
                //if(data.AmountInTipoul<amount)
                //{
                //    resobj.message = "موجودی حساب تیپول از مبلغ انتقال درخواستی کمتر می باشد";
                //    resobj.errorCode = "1010";
                //    return resultModels;
                //}

                string destinationAccountNumberF = transferType == TransferTypeEnum.LOCAL ? resultibaninfo.respObject.accountNumber : destinationAccountNumber;

                if (DateTime.Now.Hour < 6)
                    return ShowResultTransfer("", "", amount, "", "", "", "", "سرویس انتقال در این ساعت پاسخ گو نمی باشد", "10031", "200", "");

                Transfers _i = new Transfers();
                _i.bank = tokenResult.bank;
                _i.nationalCode = tokenResult.user_name;
                _i.sourceAccount = tokenResult.accounts[0];
                _i.destinationAccountNumber = destinationAccountNumberF;
                _i.amount = amount;
                _i.destinationAccountName = destinationAccountName;
                _i.transferType = transferType;
                _i.babat = babat;
                _i.withdrawDescription = withdrawDescription;
                _i.destinationBank = destinationBank;
                _i.paymentID = paymentID;
                _i.depositDescription = depositDescription;
                _i.smsPass = "";

               
                Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Transfer tr = new Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Transfer();
                
                
                var resulttransfer=  await tr.Transfers(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");
                if (resulttransfer.respObject.errorCode != null)
                {
                    if (resulttransfer.respObject.errorCode == "20000")
                        return ShowResultTransfer("", "", amount, "", "", "", "", "سرویس انتقال موقتا در دسترس نمی باشد", "10031", "200", "");
                    else
                        return ShowResultTransfer("", "", amount, "", "", "", "", "خطای سرویس انتقال", "10031", "200", "");
                }
                return ShowResultTransfer(resulttransfer.respObject.sourceAccountNumber, resulttransfer.respObject.destinationAccountNumber, resulttransfer.respObject.amount, resulttransfer.respObject.sourceBank, resulttransfer.respObject.destinationBank, Type, resulttransfer.respObject.traceNumber, resulttransfer.respObject.message, "5000", "200", "");               
            }
            else
                return ShowResultTransfer("", "", amount, "", "", "", "", "سیستم پاسخ گو نیست", "10031", "200", "");

        }
        public OutTransfer.OutModelTransfer ShowResultTransfer(string sourceAccountNumber, string destinationAccountNumber, long amount, string sourceBank, string destinationBank, string transferType, string traceNumber, string message, string messagecode, string statuscode, string trakingnumber)
        {
            OutTransfer.OutModelTransfer omt = new OutTransfer.OutModelTransfer();
            OutTransfer.ResultObjectTransfer rot = new OutTransfer.ResultObjectTransfer();

            Random rnd = new Random();
            int numberrandom = rnd.Next(100000, 999999);


            rot.sourceAccountNumber = sourceAccountNumber;
            rot.destinationAccountNumber = destinationAccountNumber;
            rot.amount = amount;
            rot.sourceBank = sourceBank;
            rot.destinationBank = destinationBank;
            rot.transferType = transferType;
            rot.traceNumber = traceNumber;




            omt.message = message;
            omt.messagecode = messagecode;
            omt.statuscode = statuscode;
            omt.tracenumber = numberrandom;
            omt.trakingnumber = trakingnumber;
            omt.resultobject = rot;

            return omt;
        }

        public async Task<Outowner.ResultObjectCart> GetCartNumber(string ApiUrl, string UserName, string Password, string tokenResult_access_token, string TokenResult_bank, string TokenResult_user_name, string source_AccountNo, string Account)
        {
            GetToken gt = new GetToken();

            Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos _i = new Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models.CardInfos();

            _i.bank = TokenResult_bank;
            _i.nationalCode = TokenResult_user_name;
            _i.sourceAccount = source_AccountNo;
            _i.cardNumber = Account;


            GeCarts m = new GeCarts();
            var result = await m.GetCardInfo(_i, ApiUrl, UserName, Password, tokenResult_access_token, "");


            Outowner.ResultObjectCart roi = new Outowner.ResultObjectCart();
            roi.bank = result.respObject.bank;
            roi.iban = result.respObject.iban;
            roi.accountNumber = result.respObject.accountNumber;
            roi.ownerName = result.respObject.ownerName;

            return roi;
        }
        public async Task<OutIban.ResultObjectIban> GetAccountNumber(string ApiUrl, string UserName, string Password, string tokenResult_access_token, string BankCode, string TokenResult_user_name, string Account)
        {

            Iban _i = new Iban();
            _i.bank = BankCode;
            _i.nationalCode = TokenResult_user_name;
            _i.sourceAccount = Account;

            GetIban m = new GetIban();
            var result = await m.GetIbans(_i, ApiUrl, UserName, Password, tokenResult_access_token, "");

            OutIban.ResultObjectIban roi = new OutIban.ResultObjectIban();

            roi.ibanNumber = result.respObject.ibanNumber;
            roi.accountNumber = result.respObject.accountNumber;

            return roi;
        }

        public async Task<IbanInfoResult?> GetIbanInfo(string ApiUrl, string UserName, string Password, string tokenResult_access_token, string tokenResult_bankname, string TokenResult_user_name, string Account)
        {

            IbanInfo _ii = new IbanInfo();
            _ii.bank = tokenResult_bankname;
            _ii.nationalCode = TokenResult_user_name;
            _ii.sourceAccount = Account;

            GetIbanInfo m = new GetIbanInfo();
            return await m.GetIbanInfos(_ii, ApiUrl, UserName, Password, tokenResult_access_token, "");

        }
        public async Task<long> GetAccountBalance(string ApiUrl, string UserName, string Password, string tokenResult_access_token, string TokenResult_bankname, string TokenResult_user_name, string TokenResult_accounts)
        {
            AccountBalance _ab = new AccountBalance();
            _ab.bank = TokenResult_bankname;
            _ab.nationalCode = TokenResult_user_name;
            _ab.sourceAccount = TokenResult_accounts;

            GetaccountBalance a = new GetaccountBalance();
            var result = await a.GetAccountBalances(_ab, ApiUrl, UserName, Password, tokenResult_access_token, "");
            return result.respObject.availableBalance;


        }
    }
}

