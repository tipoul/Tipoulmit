namespace Tipoul.Framework.StorageModels
{
    public class BusinessSubCategory
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public int BusinessCategoryId { get; set; }

        public BusinessCategory BusinessCategory { get; set; }
    }
}
