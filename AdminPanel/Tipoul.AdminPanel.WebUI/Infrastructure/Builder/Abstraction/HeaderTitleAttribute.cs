using System;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class HeaderTitleAttribute : Attribute
    {
        public HeaderTitleAttribute(string headerTitle)
        {
            HeaderTitle = headerTitle;
        }

        public string HeaderTitle { get; set; }
    }
}
