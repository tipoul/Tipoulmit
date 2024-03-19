using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Notification
{
    public class VerificationViewModel
    {
        public string ServiceName { get; set; }

        public string Type { get; set; }

        public DateTime? SeenDate { get; set; }

        public DateTime CreateDate { get; set; }

        public List<VerificationErrorViewModel> Errors { get; set; }
    }
}
