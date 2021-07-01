namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScaffoldDataLayer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        InventoryName = c.String(),
                        WeaponId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        WardrobeItemId = c.Int(nullable: false),
                        Gold = c.Int(nullable: false),
                        Silver = c.Int(nullable: false),
                        Copper = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.WardrobeItem", t => t.WardrobeItemId, cascadeDelete: true)
                .ForeignKey("dbo.Weapon", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.WeaponId)
                .Index(t => t.ItemId)
                .Index(t => t.WardrobeItemId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Description = c.String(),
                        UsesRemaining = c.Int(),
                        Inventory_InventoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Inventory", t => t.Inventory_InventoryId)
                .Index(t => t.Inventory_InventoryId);
            
            CreateTable(
                "dbo.WardrobeItem",
                c => new
                    {
                        WardobeItemId = c.Int(nullable: false, identity: true),
                        ArmorName = c.String(),
                        ArmorType = c.String(),
                        Description = c.String(),
                        HealthRequired = c.Int(nullable: false),
                        StrengthRequired = c.Int(nullable: false),
                        AgilityRequired = c.Int(nullable: false),
                        MagicRequired = c.Int(nullable: false),
                        Special = c.String(),
                        PhysicalBlocking = c.Int(nullable: false),
                        MagicalBlocking = c.Int(nullable: false),
                        PhysicalResistance = c.Int(nullable: false),
                        MagicalResistance = c.Int(nullable: false),
                        Inventory_InventoryId = c.Int(),
                    })
                .PrimaryKey(t => t.WardobeItemId)
                .ForeignKey("dbo.Inventory", t => t.Inventory_InventoryId)
                .Index(t => t.Inventory_InventoryId);
            
            CreateTable(
                "dbo.Weapon",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        WeaponName = c.String(),
                        Description = c.String(),
                        WeaponType = c.String(),
                        DamageDice = c.String(),
                        DamageModifier = c.Int(nullable: false),
                        ProwessBonus = c.Int(nullable: false),
                        Range = c.Int(nullable: false),
                        CriticalRange = c.String(),
                        Special = c.String(),
                        Parrying = c.Int(nullable: false),
                        PhysicalBlocking = c.Int(nullable: false),
                        MagicalBlocking = c.Int(nullable: false),
                        Inventory_InventoryId = c.Int(),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.Inventory", t => t.Inventory_InventoryId)
                .Index(t => t.Inventory_InventoryId);
            
            AddColumn("dbo.Character", "InventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Character", "InventoryId");
            AddForeignKey("dbo.Character", "InventoryId", "dbo.Inventory", "InventoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Weapon", "Inventory_InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Inventory", "WeaponId", "dbo.Weapon");
            DropForeignKey("dbo.Inventory", "WardrobeItemId", "dbo.WardrobeItem");
            DropForeignKey("dbo.WardrobeItem", "Inventory_InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Item", "Inventory_InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Inventory", "ItemId", "dbo.Item");
            DropIndex("dbo.Weapon", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.WardrobeItem", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.Item", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.Inventory", new[] { "WardrobeItemId" });
            DropIndex("dbo.Inventory", new[] { "ItemId" });
            DropIndex("dbo.Inventory", new[] { "WeaponId" });
            DropIndex("dbo.Character", new[] { "InventoryId" });
            DropColumn("dbo.Character", "InventoryId");
            DropTable("dbo.Weapon");
            DropTable("dbo.WardrobeItem");
            DropTable("dbo.Item");
            DropTable("dbo.Inventory");
        }
    }
}
