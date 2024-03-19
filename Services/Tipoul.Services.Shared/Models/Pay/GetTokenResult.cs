namespace Tipoul.Services.Shared.Models.Pay
{
    public class GetTokenResult
    {
        public string AccessToken { get; set; }
        public string AccessTokenHashed { get; set; }
        public string TipoulTraceNumber { get; set; }
        public string TipoulTrackNumber { get; set; }
    }
}