using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.Athentication.Web.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; private set; }
    }
}
