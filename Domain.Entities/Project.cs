using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Project : Entity
    {
        public string Cod { get; set; }

        public DateTime DateInitial { get; set; }

        public DateTime DateEnd { get; set; }

        public virtual ICollection<Risks> Risk { get; set; }
    }
}