namespace Tipoul.Framework.StorageModels
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameEn { get; set; }

        public string Code { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }
    }
}
