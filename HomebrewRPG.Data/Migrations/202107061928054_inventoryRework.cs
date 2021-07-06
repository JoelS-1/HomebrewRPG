namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventoryRework : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventory", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "Inventory_InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.WardrobeItem", "Inventory_InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Inventory", "WardrobeItemId", "dbo.WardrobeItem");
            DropForeignKey("dbo.Inventory", "WeaponId", "dbo.Weapon");
            DropForeignKey("dbo.Weapon", "Inventory_InventoryId", "dbo.Inventory");
            DropIndex("dbo.Inventory", new[] { "WeaponId" });
            DropIndex("dbo.Inventory", new[] { "ItemId" });
            DropIndex("dbo.Inventory", new[] { "WardrobeItemId" });
            DropIndex("dbo.Item", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.WardrobeItem", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.Weapon", new[] { "Inventory_InventoryId" });
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
            
            DropColumn("dbo.Item", "Inventory_InventoryId");
            DropColumn("dbo.WardrobeItem", "Inventory_InventoryId");
            DropColumn("dbo.Weapon", "Inventory_InventoryId");
            DropTable("dbo.Inventory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        InventoryName = c.String(nullable: false),
                        WeaponId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        WardrobeItemId = c.Int(nullable: false),
                        Gold = c.Int(nullable: false),
                        Silver = c.Int(nullable: false),
                        Copper = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            AddColumn("dbo.Weapon", "Inventory_InventoryId", c => c.Int());
            AddColumn("dbo.WardrobeItem", "Inventory_InventoryId", c => c.Int());
            AddColumn("dbo.Item", "Inventory_InventoryId", c => c.Int());
            DropForeignKey("dbo.Money", "CharacterId", "dbo.Character");
            DropIndex("dbo.Money", new[] { "CharacterId" });
            DropTable("dbo.Money");
            CreateIndex("dbo.Weapon", "Inventory_InventoryId");
            CreateIndex("dbo.WardrobeItem", "Inventory_InventoryId");
            CreateIndex("dbo.Item", "Inventory_InventoryId");
            CreateIndex("dbo.Inventory", "WardrobeItemId");
            CreateIndex("dbo.Inventory", "ItemId");
            CreateIndex("dbo.Inventory", "WeaponId");
            AddForeignKey("dbo.Weapon", "Inventory_InventoryId", "dbo.Inventory", "InventoryId");
            AddForeignKey("dbo.Inventory", "WeaponId", "dbo.Weapon", "WeaponId", cascadeDelete: true);
            AddForeignKey("dbo.Inventory", "WardrobeItemId", "dbo.WardrobeItem", "WardobeItemId", cascadeDelete: true);
            AddForeignKey("dbo.WardrobeItem", "Inventory_InventoryId", "dbo.Inventory", "InventoryId");
            AddForeignKey("dbo.Item", "Inventory_InventoryId", "dbo.Inventory", "InventoryId");
            AddForeignKey("dbo.Inventory", "ItemId", "dbo.Item", "ItemId", cascadeDelete: true);
        }
    }
}
