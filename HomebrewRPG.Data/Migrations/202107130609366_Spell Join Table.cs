namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpellJoinTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterSpell",
                c => new
                    {
                        CharacterSpellId = c.Int(nullable: false, identity: true),
                        SpellId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterSpellId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Spell", t => t.SpellId, cascadeDelete: true)
                .Index(t => t.SpellId)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterSpell", "SpellId", "dbo.Spell");
            DropForeignKey("dbo.CharacterSpell", "CharacterId", "dbo.Character");
            DropIndex("dbo.CharacterSpell", new[] { "CharacterId" });
            DropIndex("dbo.CharacterSpell", new[] { "SpellId" });
            DropTable("dbo.CharacterSpell");
        }
    }
}
