using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;
using Tipoul.UserPanel.WebUI.Models.Notification;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly AthenticationProvider athenticationProvider;

        private readonly TipoulFrameworkDbContext dbContext;

        public NotificationController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
        }

        public async Task<IActionResult> Index()
        {
            var user = athenticationProvider.GetUser();

            var ticketData = await dbContext.Tickets.Where(f => f.UserId == user.Id).Select(f => new
            {
                f.CreateDate,
                f.Title,
                LastMessage = f.TicketMessages.OrderByDescending(x => x.CreateDate).Select(x => x.Message).FirstOrDefault(),
                LastStatus = f.TicketStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault()
            }).ToListAsync();

            var verificationData = await dbContext.UserVerificationHistories.Where(f => f.UserId == user.Id).Select(f => new
            {
                f.CreateDate,
                f.DoneDate,
                f.SeenDate,
                Errors = f.UserVerificationHistoryErrors.Count,
                LastErrorDescription = f.UserVerificationHistoryErrors.Where(x => !string.IsNullOrWhiteSpace(x.Description)).OrderByDescending(x => x.Id).Select(x => x.Description).FirstOrDefault()
            }).ToListAsync();

            var taxData = await dbContext.UserTaxRequestHistories.Where(f => f.UserId == user.Id).Select(f => new
            {
                f.CreateDate,
                f.Duration,
                f.ErrorCode,
                f.ErrorMessage
            }).ToListAsync();

            var viewModel = new NotificationViewModel
            {
                TotalTickets = ticketData.Count,
                NewTickets = ticketData.Count(f => f.LastStatus != TicketStatusHistory.StatusType.Closed),
                LastTicketTitle = ticketData.OrderByDescending(f => f.CreateDate).Select(f => f.Title).FirstOrDefault(),
                LastTicketMessage = ticketData.OrderByDescending(f => f.CreateDate).Select(f => f.LastMessage).FirstOrDefault(),
                TotalVerifications = verificationData.Count,
                NotDoneVerifications = verificationData.Count(f => !f.DoneDate.HasValue),
                NotSeenVerifications = verificationData.Count(f => f.DoneDate.HasValue && !f.SeenDate.HasValue),
                LastVerificationErrorDescription = verificationData.Where(f => !string.IsNullOrWhiteSpace(f.LastErrorDescription)).OrderByDescending(f => f.CreateDate).Select(f => f.LastErrorDescription).FirstOrDefault(),
                TotalTaxRequests = taxData.Count,
                NotDoneTaxRequests = taxData.Count(f => !f.Duration.HasValue),
                NotSuccessTaxRequests = taxData.Count(f => f.Duration.HasValue && f.ErrorCode.HasValue),
                LastTaxRequestErrorMessage = taxData.Where(f => !string.IsNullOrWhiteSpace(f.ErrorMessage)).OrderByDescending(f => f.CreateDate).Select(f => f.ErrorMessage).FirstOrDefault()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Messages()
        {
            var user = athenticationProvider.GetUser();

            var messages = await dbContext.Notifications.Where(f => f.NotificationUsers.Any(x => x.UserId == user.Id)).ToListAsync();

            return View(messages);
        }

        public async Task<IActionResult> Tickets()
        {
            var user = athenticationProvider.GetUser();

            var data = await dbContext.Tickets
                .Include(f => f.User)
                .Include(f => f.TicketMessages)
                .Include(f => f.TicketStatusHistories).ThenInclude(f => f.User)
                .Where(f => f.UserId == user.Id).ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> Ticket(int? id)
        {
            if (!id.HasValue)
                return View();

            var ticket = await dbContext.Tickets
                .Include(f => f.TicketStatusHistories)
                .Include(f => f.TicketMessages).ThenInclude(f => f.User)
                .FirstOrDefaultAsync(f => f.Id == id.Value);

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Ticket(string title, string message, Ticket.DepartmentType department, Ticket.PriorityType priority)
        {
            var user = athenticationProvider.GetUser();

            var ticket = new Ticket
            {
                Title = title,
                UserId = user.Id,
                Priority = priority,
                Department = department,
                TicketMessages = new List<TicketMessage> { new TicketMessage { UserId = user.Id, Message = message } },
                TicketStatusHistories = new List<TicketStatusHistory> { new TicketStatusHistory { UserId = user.Id, Status = TicketStatusHistory.StatusType.New } }
            };

            await dbContext.Tickets.AddAsync(ticket);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("Ticket", new { id = ticket.Id });
        }

        public async Task<IActionResult> Verifications()
        {
            var user = athenticationProvider.GetUser();

            var verifications = await dbContext.UserVerificationHistories
                .Include(f => f.UserVerificationHistoryErrors)
                .Where(f => f.UserId == user.Id && f.DoneDate.HasValue)
                .OrderByDescending(f => f.CreateDate).ToListAsync();

            var viewModel = verifications.ConvertAll(f => new VerificationViewModel
            {
                Type = f.Type.ToString(),
                ServiceName = f.ServiceName,
                SeenDate = f.SeenDate,
                CreateDate = f.CreateDate,
                Errors = f.UserVerificationHistoryErrors.ConvertAll(x => new VerificationErrorViewModel
                {
                    FieldName = x.FieldName,
                    ErrorMessage = x.ErrorMessage,
                    Description = x.Description
                })
            });

            verifications.Where(f => !f.SeenDate.HasValue).ToList().ForEach(f => f.SeenDate = DateTime.Now);

            await dbContext.SaveChangesAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> TaxRequest()
        {
            var user = athenticationProvider.GetUser();

            var requests = await dbContext.UserTaxRequestHistories
                .Where(f => f.UserId == user.Id)
                .OrderByDescending(f => f.CreateDate).ToListAsync();

            return View(requests);
        }
    }
}
