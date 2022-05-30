namespace MVP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Pin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        State = c.String(),
                        Table_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tables", t => t.Table_Id)
                .Index(t => t.Table_Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        MaxOcc = c.Int(nullable: false),
                        Occ = c.Int(nullable: false),
                        AssignedEmployee_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AssignedEmployee_Id)
                .Index(t => t.AssignedEmployee_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Table_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tables", t => t.Table_Id)
                .Index(t => t.Table_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.Products", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.Tables", "AssignedEmployee_Id", "dbo.Employees");
            DropIndex("dbo.Products", new[] { "Table_Id" });
            DropIndex("dbo.Tables", new[] { "AssignedEmployee_Id" });
            DropIndex("dbo.Orders", new[] { "Table_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Tables");
            DropTable("dbo.Orders");
            DropTable("dbo.Employees");
        }
    }
}
