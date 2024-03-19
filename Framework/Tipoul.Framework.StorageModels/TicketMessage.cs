using System;

namespace Tipoul.Framework.StorageModels
{
    public class TicketMessage
    {
        public TicketMessage()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int TicketId { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        public string? ImageUrl { get; set; }

        public string? FileUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public Ticket Ticket { get; set; }

        public User User { get; set; }
    }
}
