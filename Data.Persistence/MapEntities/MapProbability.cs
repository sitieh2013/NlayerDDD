using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Data.Persistence.MapEntities
{
    public class MapProbability: EntityTypeConfiguration<Probability>
    {
        public MapProbability()
        {
            ToTable("probability").HasKey(i=>i.Id);

            Property(a => a.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(a => a.Name)
                .HasColumnName("Name") // Nombre columna.
                .IsRequired() // NOT NULL.
                .HasMaxLength(50); // Tamano maximo.

            HasMany(i => i.Risk)
               .WithRequired(i => i.MyProbability)
               .Map(i => i.ToTable("risks")
               .MapKey("IdProbability"));
        }
    }
}
