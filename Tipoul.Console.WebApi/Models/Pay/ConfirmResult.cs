namespace Tipoul.Services.Shared.Models.Pay
{
    public class ConfirmResult
    {
        public ConfirmStatus Status { get; set; }

        public string Message { get; set; }

        public string ReturnId { get; set; }

        public string TipoulTrackNumber { get; set; }

        public enum ConfirmStatus
        {
            OK,
            NOK,
            Duplicate
        }
    }
}