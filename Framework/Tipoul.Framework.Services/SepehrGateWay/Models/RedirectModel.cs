namespace Tipoul.Framework.Services.SepehrGateWay.Models
{
    public class RedirectModel
    {
        public RedirectModel(string token, long terminalId)
        {
            Token = token;
            TerminalId = terminalId;
        }

        public RedirectModel(string token, long terminalId, string nationalCode) : this(token, terminalId)
        {
            NationalCode = nationalCode;
        }

        public string Token { get; set; }

        public long TerminalId { get; set; }

        public string NationalCode { get; set; }
    }
}
