using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder
{
    public class FormViewModel
    {
        private List<PropertyInfo>? properties;

        public int Id { get; set; }
        public string GetTitle()
        {
            var type = GetType();

            return type.GetCustomAttribute<TitleAttribute>()?.Title ?? type.Name;
        }

        public bool IsFormPart()
        {
            return GetType().GetCustomAttribute<FormPartAttribute>() != null;
        }

        public string GetLabel(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<LabelAttribute>()?.Label ?? propertyInfo.Name;
        }

        public List<PropertyInfo> GetProperties()
        {
            if (properties == null)
                properties = GetType().GetProperties().ToList();

            return properties;
        }
    }
}
