using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Infrastructure.Builder
{
    [PageSize(ListViewModel.PageSize)]
    public class ListViewModel
    {
        public const int PageSize = 10;

        public ListViewModel(int count, int? pageNumber)
        {
            PageIndex = pageNumber.HasValue ? pageNumber.Value - 1 : 0;
            PagesCount = count / PageSize + (count % PageSize != 0 ? 1 : 0);
        }

        private Type? actualType;

        private List<PropertyInfo>? properties;

        public int PageIndex { get; set; }

        public int PagesCount { get; set; }

        public IList Items { get; set; }

        public string GetTitle()
        {
            var type = GetActualType();

            return type.GetCustomAttribute<TitleAttribute>()?.Title ?? type.Name;
        }

        public string GetHeaderTitle(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<HeaderTitleAttribute>()?.HeaderTitle ?? propertyInfo.Name;
        }

        public string GetDescription()
        {
            var type = GetActualType();

            return type.GetCustomAttribute<DescriptionAttribute>()?.Description;
        }

        public List<PropertyInfo> GetProperties()
        {
            if (properties == null)
                properties = GetActualType().GetProperties().ToList();

            return properties;
        }

        private Type GetActualType()
        {
            if (actualType == null)
                actualType = Items.GetType().GetGenericArguments().First();
            return actualType;
        }
    }
}
