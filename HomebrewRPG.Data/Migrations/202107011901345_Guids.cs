namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventory", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Item", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.WardrobeItem", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Weapon", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weapon", "OwnerId");
            DropColumn("dbo.WardrobeItem", "OwnerId");
            DropColumn("dbo.Item", "OwnerId");
            DropColumn("dbo.Inventory", "OwnerId");
        }
    }
}
