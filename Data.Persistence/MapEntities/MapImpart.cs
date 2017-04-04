using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Data.Persistence.MapEntities
{
    public class MapImpart: EntityTypeConfiguration<Impart>
    {
        public MapImpart()
        {
            ToTable("impart").HasKey(i=>i.Id);

            Property(a => a.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(a => a.Name)
                .HasColumnName("Name") // Nombre columna.
                .IsRequired() // NOT NULL.
                .HasMaxLength(50); // Tamano maximo.

            HasMany(i => i.Risk)
               .WithRequired(i => i.MyImpart)
               .Map(i => i.ToTable("risks")
               .MapKey("IdImpart"));
        }
    }
}
