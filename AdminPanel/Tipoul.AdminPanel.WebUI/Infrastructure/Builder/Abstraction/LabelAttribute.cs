using System;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LabelAttribute : Attribute
    {
        public LabelAttribute(string label)
        {
            Label = label;
        }

        public string Label { get; set; }
    }
}
