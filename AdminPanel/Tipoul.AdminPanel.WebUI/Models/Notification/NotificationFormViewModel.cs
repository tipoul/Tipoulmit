using System;
using System.Collections.Generic;
using System.Linq;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Models.Notification
{
    [Title("پیام و یا اطلاعیه")]
    public class NotificationFormViewModel : FormViewModel
    {
        public NotificationFormViewModel(Framework.StorageModels.Notification model)
        {
            Title = model.Title;
            Description = model.Description;
            ImageURL = model.ImageURL;
            FileURL = model.FileURL;
            Link = model.Link;
            UserId = model.UserId;
            Priority = (PriorityType)model.Priority;
            ExpireDate = model.ExpireDate;
        }

        public NotificationFormViewModel()
        {
        }

        [Label("عنوان")]
        public string Title { get; set; }

        [Label("توضیحات")]
        [TextArea]
        public string Description { get; set; }

        [Label("تصویر")]
        [File]
        public string? ImageURL { get; set; }

        [Label("فایل")]
        [File]
        public string? FileURL { get; set; }

        [Label("لینک")]
        public string? Link { get; set; }

        [Label("کاربر")]
        [Partial("formComponents/user")]
        public int UserId { get; set; }

        [Label("اولویت")]
        public PriorityType Priority { get; set; }

        [Label("تاریخ انقضا")]
        public DateTime? ExpireDate { get; set; }

        public enum PriorityType
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

        public static Dictionary<int, string> GetPriorityValues()
        {
            return Framework.StorageModels.Notification.GetAllPriorityTypes().ToDictionary(priorityType => (int)priorityType, priorityType => Framework.StorageModels.Notification.GetPriorityTypeName(priorityType));
        }
    }
}
