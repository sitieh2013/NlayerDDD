using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Persistence.MapEntities;

namespace Data.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base(Connection.Connected()) {}

        public DataBaseContext(EnumDataProvider dataProvider) :
            base(Connection.Connected(dataProvider)) {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new MapImpart());
            modelBuilder.Configurations.Add(new MapProbability());
            modelBuilder.Configurations.Add(new MapProject());
            modelBuilder.Configurations.Add(new MapRisk());

            base.OnModelCreating(modelBuilder);
        }
    }
}
