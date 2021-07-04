namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeroicChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Heroic", "HeroicName", c => c.String(nullable: false));
            AlterColumn("dbo.Heroic", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Heroic", "RequiredHeroic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Heroic", "RequiredHeroic", c => c.String());
            AlterColumn("dbo.Heroic", "Description", c => c.String());
            AlterColumn("dbo.Heroic", "HeroicName", c => c.String());
        }
    }
}
