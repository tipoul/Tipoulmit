namespace Tipoul.Athentication.Web.ViewModels
{
    public class LoginResult
    {
        public bool VerificationCodeSent { get; set; }

        public bool InVerificationCode { get; set; }

        public bool PasswordNeeded { get; set; }

        public bool NotExists { get; set; }

        public bool Banded { get; set; }

        public string Token { get; set; }
    }
}
