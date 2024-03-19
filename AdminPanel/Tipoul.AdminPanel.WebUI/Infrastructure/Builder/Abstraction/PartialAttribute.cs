using System;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class PartialAttribute : Attribute
	{
		public PartialAttribute(string path)
		{
			Path = path;
		}

		public string Path { get; set; }
	}
}
