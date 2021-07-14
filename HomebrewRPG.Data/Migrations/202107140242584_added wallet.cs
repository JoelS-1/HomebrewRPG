namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedwallet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Money", "CharacterId", "dbo.Character");
            DropIndex("dbo.Money", new[] { "CharacterId" });
            CreateTable(
                "dbo.Wallet",
                c => new
                    {
                        WalletId = c.Int(nullable: false, identity: true),
                        Gold = c.Int(nullable: false),
                        Silver = c.Int(nullable: false),
                        Copper = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.WalletId);
            
            DropTable("dbo.Money");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.MoneyId);
            
            DropTable("dbo.Wallet");
            CreateIndex("dbo.Money", "CharacterId");
            AddForeignKey("dbo.Money", "CharacterId", "dbo.Character", "CharacterId", cascadeDelete: true);
        }
    }
}
