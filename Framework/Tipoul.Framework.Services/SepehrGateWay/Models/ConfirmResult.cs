namespace Tipoul.Framework.Services.SepehrGateWay.Models
{
    public class ConfirmResult
    {
        public string Status { get; set; }

        public string ReturnId { get; set; }

        public string Message { get; set; }

        public enum ConfirmStatus
        {
            OK,
            NOK,
            Duplicate
        }
    }
}
