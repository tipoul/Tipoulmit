using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class State
    {
        public State()
        {
            Cities = new List<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<City> Cities { get; set; }
    }
}
