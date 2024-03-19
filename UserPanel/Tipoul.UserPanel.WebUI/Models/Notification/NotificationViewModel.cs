using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Notification
{
    public class NotificationViewModel
    {
        public int TotalTickets { get; set; }

        public int NewTickets { get; set; }

        public string LastTicketTitle { get; set; }

        public string LastTicketMessage { get; set; }

        public int TotalVerifications { get; set; }

        public int NotDoneVerifications { get; set; }

        public int NotSeenVerifications { get; set; }

        public string LastVerificationErrorDescription { get; set; }

        public int TotalTaxRequests { get; set; }

        public int NotDoneTaxRequests { get; set; }

        public int NotSuccessTaxRequests { get; set; }

        public string LastTaxRequestErrorMessage { get; set; }
    }
}
