namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(nullable: false),
                        Race = c.String(nullable: false),
                        CharacterLevel = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Allignment = c.String(),
                        Health = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Instinct = c.Int(nullable: false),
                        Agility = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Charisma = c.Int(nullable: false),
                        MagicType = c.String(nullable: false),
                        ProwessType = c.String(nullable: false),
                        Proficiency = c.Int(nullable: false),
                        HitPoints = c.Int(nullable: false),
                        Sanity = c.Int(nullable: false),
                        Dodge = c.Int(nullable: false),
                        Reaction = c.Int(nullable: false),
                        BaseProwess = c.Int(nullable: false),
                        Magic = c.Int(nullable: false),
                        Fate = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                        Endurance = c.Int(nullable: false),
                        Constitution = c.Int(nullable: false),
                        Athletics = c.Int(nullable: false),
                        Tenacity = c.Int(nullable: false),
                        Acrobatics = c.Int(nullable: false),
                        SleightOfHand = c.Int(nullable: false),
                        Sneak = c.Int(nullable: false),
                        Willpower = c.Int(nullable: false),
                        Investigation = c.Int(nullable: false),
                        Knowledge = c.Int(nullable: false),
                        Bravery = c.Int(nullable: false),
                        Pilotry = c.Int(nullable: false),
                        Insight = c.Int(nullable: false),
                        Perception = c.Int(nullable: false),
                        Survival = c.Int(nullable: false),
                        Faith = c.Int(nullable: false),
                        Deception = c.Int(nullable: false),
                        Diplomacy = c.Int(nullable: false),
                        Intimidation = c.Int(nullable: false),
                        Performance = c.Int(nullable: false),
                        Seduction = c.Int(nullable: false),
                        DamageResistance = c.Int(nullable: false),
                        MagicResistance = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
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
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Character");
        }
    }
}
