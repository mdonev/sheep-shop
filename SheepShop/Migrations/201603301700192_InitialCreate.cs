namespace SheepShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Herds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        sex = c.Int(nullable: false),
                        BornDate = c.DateTime(nullable: false),
                        shipAge = c.Double(nullable: false),
                        milk = c.Double(nullable: false),
                        totalMilk = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Herds");
        }
    }
}
