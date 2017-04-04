using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Data.Persistence.MapEntities
{
    public class MapProject : EntityTypeConfiguration<Project>
    {
        public MapProject()
        {
            ToTable("project").HasKey(i => i.Id);

            Property(a => a.Id)
                .HasColumnName("Id").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Cod)
                .HasColumnName("Cod") 
                .IsRequired() 
                .HasMaxLength(50); 

            Property(a => a.DateInitial)
                .HasColumnName("DateInitial") 
                .IsRequired();

            Property(a => a.DateEnd)
                .HasColumnName("DateEnd") 
                .IsRequired(); 

            HasMany(i => i.Risk)
                .WithRequired(i => i.MyProject)
                .Map(i => i.ToTable("risks")
                .MapKey("IdProject"));
        }
    }
}
