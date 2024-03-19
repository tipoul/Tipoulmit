using System;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class PageSizeAttribute : Attribute
    {
        public PageSizeAttribute(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get; set; }
    }
}
