using System;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class HasButtonAttribute : Attribute
    {
        public HasButtonAttribute(string methodName, string label, string bootstrapColorClass)
        {
            Label = label;
            BootstrapColorClass = bootstrapColorClass;
            UniqeId = Guid.NewGuid().ToString();
            MethodName = methodName.Replace("{uniqeId}", UniqeId);
        }

        public string MethodName { get; set; }

        public string Label { get; set; }

        public string BootstrapColorClass { get; set; }

        public string UniqeId { get; set; }

        public string DataKey { get; set; }

        public string DataValue { get; set; }
    }
}
