namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class walletFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wallet", "CharacterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Wallet", "CharacterId");
            AddForeignKey("dbo.Wallet", "CharacterId", "dbo.Character", "CharacterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallet", "CharacterId", "dbo.Character");
            DropIndex("dbo.Wallet", new[] { "CharacterId" });
            DropColumn("dbo.Wallet", "CharacterId");
        }
    }
}
