using System;

namespace Tipoul.Framework.StorageModels
{
    public class UserAvatarHistory
    {
        public UserAvatarHistory()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string AvatarURL { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }
    }
}
