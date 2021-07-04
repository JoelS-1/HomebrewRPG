namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNullableInts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroic",
                c => new
                    {
                        HeroicId = c.Int(nullable: false, identity: true),
                        HeroicName = c.String(),
                        IsPersonalHeroic = c.Boolean(nullable: false),
                        Description = c.String(),
                        RequiredLevel = c.Int(nullable: false),
                        RequiredHeroic = c.String(),
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
            
            AddColumn("dbo.Item", "Uses", c => c.Int(nullable: false));
            DropColumn("dbo.Item", "UsesRemaining");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "UsesRemaining", c => c.Int());
            DropColumn("dbo.Item", "Uses");
            DropTable("dbo.Spell");
            DropTable("dbo.Heroic");
        }
    }
}
