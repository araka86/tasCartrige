namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cartrigelolocations", "CountCartrige", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cartrigelolocations", "CountCartrige");
        }
    }
}
