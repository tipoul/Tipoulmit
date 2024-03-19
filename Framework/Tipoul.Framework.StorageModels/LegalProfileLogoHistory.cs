using System;

namespace Tipoul.Framework.StorageModels
{
    public class LegalProfileLogoHistory
    {
        public LegalProfileLogoHistory()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int LegalProfileId { get; set; }

        public string LogoUrl { get; set; }

        public LegalProfile LegalProfile { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
