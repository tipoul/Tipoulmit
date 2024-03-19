using System;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }

        public int MaxLength { get; set; }
    }
}
