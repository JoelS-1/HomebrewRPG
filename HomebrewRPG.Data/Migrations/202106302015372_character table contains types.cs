namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class charactertablecontainstypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "Instinct", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "MagicType", c => c.String(nullable: false));
            AddColumn("dbo.Character", "ProwessType", c => c.String(nullable: false));
            AddColumn("dbo.Character", "Proficiency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Character", "Proficiency");
            DropColumn("dbo.Character", "ProwessType");
            DropColumn("dbo.Character", "MagicType");
            DropColumn("dbo.Character", "Instinct");
        }
    }
}
