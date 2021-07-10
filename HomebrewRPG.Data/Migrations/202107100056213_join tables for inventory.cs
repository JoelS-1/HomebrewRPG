namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jointablesforinventory : DbMigration
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
                "dbo.CharacterWeapon",
                c => new
                    {
                        CharacterItemId = c.Int(nullable: false, identity: true),
                        WeaponId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        IsEquipped = c.Boolean(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterItemId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Weapon", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.WeaponId)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterWeapon", "WeaponId", "dbo.Weapon");
            DropForeignKey("dbo.CharacterWeapon", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterWardrobe", "WardrobeItemId", "dbo.WardrobeItem");
            DropForeignKey("dbo.CharacterWardrobe", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.CharacterItem", "CharacterId", "dbo.Character");
            DropIndex("dbo.CharacterWeapon", new[] { "CharacterId" });
            DropIndex("dbo.CharacterWeapon", new[] { "WeaponId" });
            DropIndex("dbo.CharacterWardrobe", new[] { "CharacterId" });
            DropIndex("dbo.CharacterWardrobe", new[] { "WardrobeItemId" });
            DropIndex("dbo.CharacterItem", new[] { "CharacterId" });
            DropIndex("dbo.CharacterItem", new[] { "ItemId" });
            DropTable("dbo.CharacterWeapon");
            DropTable("dbo.CharacterWardrobe");
            DropTable("dbo.CharacterItem");
        }
    }
}
