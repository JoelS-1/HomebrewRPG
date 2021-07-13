namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "IsConsumable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "IsConsumable");
        }
    }
}
