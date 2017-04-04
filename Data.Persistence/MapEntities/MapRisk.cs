using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Data.Persistence.MapEntities
{
    public class MapRisk : EntityTypeConfiguration<Risks>
    {
        public MapRisk()
        {
            ToTable("risks").HasKey(i => i.Id);

            Property(a => a.Id)
                .HasColumnName("Id").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Name)
                .HasColumnName("Name") // Nombre columna.
                .IsRequired(); // NOT NULL.
        }
    }
}
