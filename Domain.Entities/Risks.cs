namespace Domain.Entities
{
    public class Risks : Entity
    {
        public string Name { get; set; }

        public virtual Project MyProject { get; set; }

        public virtual Impart MyImpart {get; set;}
        
        public virtual Probability MyProbability { get; set; }
    }
}