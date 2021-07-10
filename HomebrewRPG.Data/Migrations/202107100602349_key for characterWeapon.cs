namespace HomebrewRPG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keyforcharacterWeapon : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CharacterWeapon");
            AddColumn("dbo.CharacterWeapon", "CharacterWeaponId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CharacterWeapon", "CharacterWeaponId");
            DropColumn("dbo.CharacterWeapon", "CharacterItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharacterWeapon", "CharacterItemId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CharacterWeapon");
            DropColumn("dbo.CharacterWeapon", "CharacterWeaponId");
            AddPrimaryKey("dbo.CharacterWeapon", "CharacterItemId");
        }
    }
}
