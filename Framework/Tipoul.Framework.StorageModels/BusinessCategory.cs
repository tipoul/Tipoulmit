using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class BusinessCategory
    {
        public BusinessCategory()
        {
            BusinessSubCategories = new List<BusinessSubCategory>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public List<BusinessSubCategory> BusinessSubCategories { get; set; }
    }
}
