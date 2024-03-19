namespace Tipoul.Framework.StorageModels
{
    public class UserVerificationHistoryError
    {
        public int Id { get; set; }

        public int UserVerificationHistoryId { get; set; }

        public string? FieldName { get; set; }

        public string ErrorMessage { get; set; }

        public string? Description { get; set; }

        public UserVerificationHistory UserVerificationHistory { get; set; }
    }
}
