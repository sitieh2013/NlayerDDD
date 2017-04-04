using System.Collections.Generic;

namespace Domain.Entities
{
    public class Probability : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Risks> Risk { get; set; }
    }
}