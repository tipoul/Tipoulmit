namespace Tipoul.UserPanel.WebUI.Models.Wizard.Profile
{
    public class VerifyModel
    {
        public string NationalCardPictureURL { get; set; }

        public string NationalCardPictureRejectReason { get; set; }

        public bool IsNationalCardPictureAccepted { get; set; }

        public string BirthCertificatePictureURL { get; set; }

        public string BirthCertificatePictureRejectReason { get; set; }

        public bool IsBirthCertificatePictureAccepted { get; set; }

        public string VerificationPictureURL { get; set; }

        public string VerificationPictureRejectReson { get; set; }

        public bool IsVerificationPictureAccepted { get; set; }

        public enum IdentityDocumentType
        {
            Newsletter = 1,
            NationalCard = 2,
            BirthCertificate = 3,
            Verification = 4
        }
    }
}
