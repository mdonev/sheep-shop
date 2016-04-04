namespace SheepShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class herd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Herds", "T");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Herds", "T", c => c.Int(nullable: false));
        }
    }
}
