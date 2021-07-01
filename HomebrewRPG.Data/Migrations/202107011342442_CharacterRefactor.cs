namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterRefactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "HitPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Sanity", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Dodge", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Reaction", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "BaseProwess", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Magic", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Fate", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Speed", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Endurance", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Constitution", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Athletics", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Tenacity", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Acrobatics", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "SleightOfHand", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Sneak", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Willpower", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Investigation", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Knowledge", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Bravery", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Pilotry", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Insight", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Perception", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Survival", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Faith", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Deception", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Diplomacy", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Intimidation", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Performance", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "Seduction", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "DamageResistance", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "MagicResistance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Character", "MagicResistance");
            DropColumn("dbo.Character", "DamageResistance");
            DropColumn("dbo.Character", "Seduction");
            DropColumn("dbo.Character", "Performance");
            DropColumn("dbo.Character", "Intimidation");
            DropColumn("dbo.Character", "Diplomacy");
            DropColumn("dbo.Character", "Deception");
            DropColumn("dbo.Character", "Faith");
            DropColumn("dbo.Character", "Survival");
            DropColumn("dbo.Character", "Perception");
            DropColumn("dbo.Character", "Insight");
            DropColumn("dbo.Character", "Pilotry");
            DropColumn("dbo.Character", "Bravery");
            DropColumn("dbo.Character", "Knowledge");
            DropColumn("dbo.Character", "Investigation");
            DropColumn("dbo.Character", "Willpower");
            DropColumn("dbo.Character", "Sneak");
            DropColumn("dbo.Character", "SleightOfHand");
            DropColumn("dbo.Character", "Acrobatics");
            DropColumn("dbo.Character", "Tenacity");
            DropColumn("dbo.Character", "Athletics");
            DropColumn("dbo.Character", "Constitution");
            DropColumn("dbo.Character", "Endurance");
            DropColumn("dbo.Character", "Speed");
            DropColumn("dbo.Character", "Fate");
            DropColumn("dbo.Character", "Magic");
            DropColumn("dbo.Character", "BaseProwess");
            DropColumn("dbo.Character", "Reaction");
            DropColumn("dbo.Character", "Dodge");
            DropColumn("dbo.Character", "Sanity");
            DropColumn("dbo.Character", "HitPoints");
        }
    }
}
