namespace Tipoul.Framework.Services.SepehrGateWay.Models
{
    public class ConfirmModel
    {
        public ConfirmModel(string digitalreceipt, long terminalId)
        {
            Digitalreceipt = digitalreceipt;
            Tid = terminalId;
        }

        public string Digitalreceipt { get; set; }

        public long Tid { get; set; }
    }
}
