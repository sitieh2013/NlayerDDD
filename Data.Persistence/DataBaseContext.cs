using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Persistence.MapEntities;
using Microsoft.AspNet.Identity.EntityFramework;

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

            OnModelCreatingSecurity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void OnModelCreatingSecurity(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            var modelIdentityUser = modelBuilder.Entity<IdentityUser>();

            //Usuario:
            modelIdentityUser.ToTable("SecurityUsers")
                .Property(u => u.UserName)
                .IsRequired();
            modelIdentityUser.HasMany(u => u.Roles);

            modelBuilder.Entity<IdentityUserRole>().HasKey(r =>
                new { r.UserId, r.RoleId }).ToTable("SecurityUserRoles");

            // Leave this alone:
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l =>
                new
                {
                    l.UserId,
                    l.LoginProvider,
                    l.ProviderKey,
                }).ToTable("SecurityUserLogins");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("SecurityUserClaims");

            //Roles
            modelBuilder.Entity<IdentityRole>().ToTable("SecurityRoles")
                .Property(r => r.Name)
                .IsRequired();
        }
    }
}
