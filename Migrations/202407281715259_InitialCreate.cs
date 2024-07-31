namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartrigeIssues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CartrigeModels", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.CartrigeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartrigePurchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CartrigeModels", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Cartrigelolocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(),
                        Cartrige = c.String(),
                        Article = c.String(),
                        Weight = c.Double(nullable: false),
                        Status = c.String(),
                        CountCartige = c.Int(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cartriges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelCartrige = c.String(),
                        ArticleCartrige = c.String(),
                        purchase_date = c.DateTime(),
                        CountCartrige = c.Int(nullable: false),
                        IsService = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compatibilities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        CartrigeId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cartriges", t => t.CartrigeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CartrigeId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Printers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimes = c.DateTime(),
                        ModelPrinter = c.String(),
                        Article = c.String(),
                        DepartmentId = c.Int(),
                        CartrigeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cartriges", t => t.CartrigeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CartrigeId);
            
            CreateTable(
                "dbo.CountCartiges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelCartrige = c.String(),
                        CountCartrige = c.Int(nullable: false),
                        purchase_date = c.DateTime(),
                        CartrigeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cartriges", t => t.CartrigeId, cascadeDelete: true)
                .Index(t => t.CartrigeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LasttName = c.String(),
                        LoginId = c.String(),
                        Role = c.String(),
                        UniqId = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CountCartiges", "CartrigeId", "dbo.Cartriges");
            DropForeignKey("dbo.Compatibilities", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Printers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Printers", "CartrigeId", "dbo.Cartriges");
            DropForeignKey("dbo.Compatibilities", "CartrigeId", "dbo.Cartriges");
            DropForeignKey("dbo.CartrigeIssues", "ModelId", "dbo.CartrigeModels");
            DropForeignKey("dbo.CartrigePurchases", "ModelId", "dbo.CartrigeModels");
            DropIndex("dbo.CountCartiges", new[] { "CartrigeId" });
            DropIndex("dbo.Printers", new[] { "CartrigeId" });
            DropIndex("dbo.Printers", new[] { "DepartmentId" });
            DropIndex("dbo.Compatibilities", new[] { "CartrigeId" });
            DropIndex("dbo.Compatibilities", new[] { "DepartmentId" });
            DropIndex("dbo.CartrigePurchases", new[] { "ModelId" });
            DropIndex("dbo.CartrigeIssues", new[] { "ModelId" });
            DropTable("dbo.Users");
            DropTable("dbo.CountCartiges");
            DropTable("dbo.Printers");
            DropTable("dbo.Departments");
            DropTable("dbo.Compatibilities");
            DropTable("dbo.Cartriges");
            DropTable("dbo.Cartrigelolocations");
            DropTable("dbo.CartrigePurchases");
            DropTable("dbo.CartrigeModels");
            DropTable("dbo.CartrigeIssues");
        }
    }
}
