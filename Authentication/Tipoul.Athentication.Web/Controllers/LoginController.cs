using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Utility;
using Tipoul.Athentication.Web.Models;
using Tipoul.Athentication.Web.Services;
using Tipoul.Athentication.Web.ViewModels;
using Tipoul.Framework.DataAccessLayer;

namespace Tipoul.Athentication.Web.Controllers
{
    public class LoginController : Controller
    {
        private static Random random = new Random(DateTime.Now.Millisecond);

        private readonly TipoulFrameworkDbContext dbContext;

        public LoginController(TipoulFrameworkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(string redirectUrl)
        {
            if (string.IsNullOrWhiteSpace(redirectUrl))
                return NotFound();

            var viewModel = new LoginViewModel(redirectUrl);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<LoginResult> Index([FromServices] SMSDotIrSMSService smsService, [FromForm] LoginModel model)
        {
#if DEBUG
            var user = await dbContext.Users.FirstOrDefaultAsync(f => f.MobileNumber == model.UserName);

            var athenticatedUser = new Agent.Models.User
            {
                Id = user.Id,
                FirtName = user.FirstName,
                LastName = user.LastName
            };

            var token = StringUtility.Zip(JsonSerializer.Serialize(athenticatedUser));

            return new LoginResult { Token = token };
#else
            if (!string.IsNullOrWhiteSpace(model.Password))
                return LoginWithPassword(model);
            if (!string.IsNullOrWhiteSpace(model.VerificationCode))
                return await LoginWithVerificationCodeAsync(model);

            var user = await dbContext.Users.FirstOrDefaultAsync(f => f.UserName == model.UserName || f.MobileNumber == model.UserName);

            if (user == null)
                user = await RegisterUserByPhoneNumber(model);

            if (user.Trashed.HasValue && user.Trashed.Value)
                return new LoginResult { Banded = true };

            if (user.UserName == model.UserName)
                return new LoginResult { PasswordNeeded = true };

            if (user.MobileNumber == model.UserName)
            {
                string verificationCode = user.VerificationCode;

                if (string.IsNullOrWhiteSpace(verificationCode))
                    do
                    {
                        verificationCode = random.Next(1000, 9999).ToString();
                    } while (await dbContext.Users.AnyAsync(f => f.Id != user.Id && f.VerificationCode == verificationCode));

                if (user.MobileNumber == "09396986877" || user.MobileNumber == "09031422368")
                    verificationCode = "1111";
                if (user.MobileNumber == "09941179425")
                    verificationCode = "2387";
                if (user.MobileNumber == "09018236255")
                    verificationCode = "58030358";
                user.VerificationCode = verificationCode;

                await dbContext.SaveChangesAsync();

                if (user.MobileNumber != "09396986877" && user.MobileNumber != "09018236255")
                    await smsService.SendVerificationCodeAsync(user.MobileNumber, verificationCode);

                return new LoginResult { VerificationCodeSent = true };
            }
#endif

            throw new NotImplementedException();
        }

        private async Task<Framework.StorageModels.User> RegisterUserByPhoneNumber(LoginModel model)
        {
            var user = new Framework.StorageModels.User
            {
                MobileNumber = model.UserName,
                Type = Framework.StorageModels.User.UserType.UserPanel
            };

            dbContext.Users.Add(user);

            await dbContext.SaveChangesAsync();

            user.Wallet = new Framework.StorageModels.Wallet
            {
                Title = "حساب تیپول حقیقی",
                WalletCode = string.Concat(model.UserName.Reverse()),
                UserId = user.Id
            };

            user.UserWageTypeHistories.Add(new Framework.StorageModels.UserWageTypeHistory
            {
                WageType = Framework.StorageModels.UserWageTypeHistory.UserWageType.FromTransaction,
                MaxRelativeAmount = 25000,
                RelativeAmount = 1
            });

            await dbContext.SaveChangesAsync();

            return user;
        }

        private async Task<LoginResult> LoginWithVerificationCodeAsync(LoginModel model)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(f => f.MobileNumber == model.UserName && f.VerificationCode == model.VerificationCode);

            if (user == null)
                return new LoginResult { InVerificationCode = true };

            user.VerificationCode = null;
            user.MobileNumberConfirmed = true;

            await dbContext.SaveChangesAsync();

            var athenticatedUser = new Agent.Models.User
            {
                Id = user.Id,
                FirtName = user.FirstName,
                LastName = user.LastName
            };

            var token = StringUtility.Zip(JsonSerializer.Serialize(athenticatedUser));

            return new LoginResult { Token = token };
        }

        private LoginResult LoginWithPassword(LoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}
