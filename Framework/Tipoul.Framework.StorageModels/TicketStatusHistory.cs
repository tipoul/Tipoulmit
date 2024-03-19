using System;

namespace Tipoul.Framework.StorageModels
{
    public class TicketStatusHistory
    {
        public TicketStatusHistory()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int TicketId { get; set; }

        public int UserId { get; set; }

        public StatusType Status { get; set; }

        public DateTime CreateDate { get; set; }

        public Ticket Ticket { get; set; }

        public User User { get; set; }

        public enum StatusType
        {
            New = 1,
            Closed = 2
        }
    }
}
