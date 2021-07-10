namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterItem",
                c => new
                    {
                        CharacterItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        RemainingUses = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterItemId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.CharacterId);
            
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
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Uses = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.CharacterWardrobe",
                c => new
                    {
                        CharacterWardobeId = c.Int(nullable: false, identity: true),
                        WardrobeItemId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        IsEquipped = c.Boolean(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterWardobeId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.WardrobeItem", t => t.WardrobeItemId, cascadeDelete: true)
                .Index(t => t.WardrobeItemId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.WardrobeItem",
                c => new
                    {
                        WardobeItemId = c.Int(nullable: false, identity: true),
                        ArmorName = c.String(nullable: false),
                        ArmorType = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        HealthRequired = c.Int(nullable: false),
                        StrengthRequired = c.Int(nullable: false),
                        AgilityRequired = c.Int(nullable: false),
                        MagicRequired = c.Int(nullable: false),
                        Special = c.String(nullable: false),
                        PhysicalBlocking = c.Int(nullable: false),
                        MagicalBlocking = c.Int(nullable: false),
                        PhysicalResistance = c.Int(nullable: false),
                        MagicalResistance = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.WardobeItemId);
            
            CreateTable(
                "dbo.CharacterWeapon",
                c => new
                    {
                        CharacterWeaponId = c.Int(nullable: false, identity: true),
                        WeaponId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        IsEquipped = c.Boolean(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterWeaponId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Weapon", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.WeaponId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Weapon",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        WeaponName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        WeaponType = c.String(nullable: false),
                        DamageDice = c.String(nullable: false),
                        DamageModifier = c.Int(nullable: false),
                        ProwessBonus = c.Int(nullable: false),
                        Range = c.Int(nullable: false),
                        CriticalRange = c.String(nullable: false),
                        Special = c.String(nullable: false),
                        Parrying = c.Int(nullable: false),
                        PhysicalBlocking = c.Int(nullable: false),
                        MagicalBlocking = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.WeaponId);
            
            CreateTable(
                "dbo.Heroic",
                c => new
                    {
                        HeroicId = c.Int(nullable: false, identity: true),
                        HeroicName = c.String(nullable: false),
                        IsPersonalHeroic = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        RequiredLevel = c.Int(nullable: false),
                        RequiredHeroic = c.String(nullable: false),
                        RequiredAgility = c.Int(nullable: false),
                        RequiredStrength = c.Int(nullable: false),
                        RequiredInstinct = c.Int(nullable: false),
                        RequiredIntelligence = c.Int(nullable: false),
                        RequiredCharisma = c.Int(nullable: false),
                        RequiredHealth = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.HeroicId);
            
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
                "dbo.Spell",
                c => new
                    {
                        SpellId = c.Int(nullable: false, identity: true),
                        SpellName = c.String(nullable: false),
                        SpellDescription = c.String(nullable: false),
                        SpellEffect = c.String(nullable: false),
                        SpellType = c.String(nullable: false),
                        Range = c.Int(nullable: false),
                        SpellDC = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SpellId);
            
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
            
            CreateTable(
                "dbo.Money",
                c => new
                    {
                        MoneyId = c.Int(nullable: false, identity: true),
                        Gold = c.Int(nullable: false),
                        Silver = c.Int(nullable: false),
                        Copper = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.MoneyId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Money", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CharacterWeapon", "WeaponId", "dbo.Weapon");
            DropForeignKey("dbo.CharacterWeapon", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterWardrobe", "WardrobeItemId", "dbo.WardrobeItem");
            DropForeignKey("dbo.CharacterWardrobe", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.CharacterItem", "CharacterId", "dbo.Character");
            DropIndex("dbo.Money", new[] { "CharacterId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CharacterWeapon", new[] { "CharacterId" });
            DropIndex("dbo.CharacterWeapon", new[] { "WeaponId" });
            DropIndex("dbo.CharacterWardrobe", new[] { "CharacterId" });
            DropIndex("dbo.CharacterWardrobe", new[] { "WardrobeItemId" });
            DropIndex("dbo.CharacterItem", new[] { "CharacterId" });
            DropIndex("dbo.CharacterItem", new[] { "ItemId" });
            DropTable("dbo.Money");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Spell");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Heroic");
            DropTable("dbo.Weapon");
            DropTable("dbo.CharacterWeapon");
            DropTable("dbo.WardrobeItem");
            DropTable("dbo.CharacterWardrobe");
            DropTable("dbo.Item");
            DropTable("dbo.Character");
            DropTable("dbo.CharacterItem");
        }
    }
}
