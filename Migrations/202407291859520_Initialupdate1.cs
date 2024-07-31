namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialupdate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cartrigelolocations", "CountCartrige");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cartrigelolocations", "CountCartrige", c => c.Int(nullable: false));
        }
    }
}
