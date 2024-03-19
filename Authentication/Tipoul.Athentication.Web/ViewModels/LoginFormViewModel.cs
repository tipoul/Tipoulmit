using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.Athentication.Web.ViewModels
{
    public class LoginFormViewModel
    {
        public LoginFormViewModel(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; private set; }
    }
}
