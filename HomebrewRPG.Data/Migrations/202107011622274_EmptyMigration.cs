namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventory", "InventoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Item", "ItemName", c => c.String(nullable: false));
            AlterColumn("dbo.Item", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.WardrobeItem", "ArmorName", c => c.String(nullable: false));
            AlterColumn("dbo.WardrobeItem", "ArmorType", c => c.String(nullable: false));
            AlterColumn("dbo.WardrobeItem", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.WardrobeItem", "Special", c => c.String(nullable: false));
            AlterColumn("dbo.Weapon", "WeaponName", c => c.String(nullable: false));
            AlterColumn("dbo.Weapon", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Weapon", "WeaponType", c => c.String(nullable: false));
            AlterColumn("dbo.Weapon", "DamageDice", c => c.String(nullable: false));
            AlterColumn("dbo.Weapon", "CriticalRange", c => c.String(nullable: false));
            AlterColumn("dbo.Weapon", "Special", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weapon", "Special", c => c.String());
            AlterColumn("dbo.Weapon", "CriticalRange", c => c.String());
            AlterColumn("dbo.Weapon", "DamageDice", c => c.String());
            AlterColumn("dbo.Weapon", "WeaponType", c => c.String());
            AlterColumn("dbo.Weapon", "Description", c => c.String());
            AlterColumn("dbo.Weapon", "WeaponName", c => c.String());
            AlterColumn("dbo.WardrobeItem", "Special", c => c.String());
            AlterColumn("dbo.WardrobeItem", "Description", c => c.String());
            AlterColumn("dbo.WardrobeItem", "ArmorType", c => c.String());
            AlterColumn("dbo.WardrobeItem", "ArmorName", c => c.String());
            AlterColumn("dbo.Item", "Description", c => c.String());
            AlterColumn("dbo.Item", "ItemName", c => c.String());
            AlterColumn("dbo.Inventory", "InventoryName", c => c.String());
        }
    }
}
