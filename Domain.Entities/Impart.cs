using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Impart: Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Risks> Risk { get; set; }
    }
}