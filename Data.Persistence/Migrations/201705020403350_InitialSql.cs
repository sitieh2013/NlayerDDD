namespace Data.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSql : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.impart",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.risks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IdProbability = c.Long(nullable: false),
                        IdProject = c.Long(nullable: false),
                        IdImpart = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.probability", t => t.IdProbability, cascadeDelete: true)
                .ForeignKey("dbo.project", t => t.IdProject, cascadeDelete: true)
                .ForeignKey("dbo.impart", t => t.IdImpart, cascadeDelete: true)
                .Index(t => t.IdProbability)
                .Index(t => t.IdProject)
                .Index(t => t.IdImpart);
            
            CreateTable(
                "dbo.probability",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.project",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Cod = c.String(nullable: false, maxLength: 50),
                        DateInitial = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecurityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecurityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecurityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.SecurityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.SecurityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.SecurityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.SecurityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.SecurityRoles", t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.SecurityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecurityUserRoles", "IdentityRole_Id", "dbo.SecurityRoles");
            DropForeignKey("dbo.SecurityUserRoles", "IdentityUser_Id", "dbo.SecurityUsers");
            DropForeignKey("dbo.SecurityUserLogins", "IdentityUser_Id", "dbo.SecurityUsers");
            DropForeignKey("dbo.SecurityUserClaims", "IdentityUser_Id", "dbo.SecurityUsers");
            DropForeignKey("dbo.risks", "IdImpart", "dbo.impart");
            DropForeignKey("dbo.risks", "IdProject", "dbo.project");
            DropForeignKey("dbo.risks", "IdProbability", "dbo.probability");
            DropIndex("dbo.SecurityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.SecurityUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.SecurityUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.SecurityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.risks", new[] { "IdImpart" });
            DropIndex("dbo.risks", new[] { "IdProject" });
            DropIndex("dbo.risks", new[] { "IdProbability" });
            DropTable("dbo.SecurityRoles");
            DropTable("dbo.SecurityUserRoles");
            DropTable("dbo.SecurityUserLogins");
            DropTable("dbo.SecurityUserClaims");
            DropTable("dbo.SecurityUsers");
            DropTable("dbo.project");
            DropTable("dbo.probability");
            DropTable("dbo.risks");
            DropTable("dbo.impart");
        }
    }
}
