namespace LibraryManager.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Isbn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TakedAt = c.DateTime(nullable: false),
                        ReturnAt = c.DateTime(nullable: false),
                        LibraryCardId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.LibraryCards", t => t.LibraryCardId, cascadeDelete: true)
                .Index(t => t.LibraryCardId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.LibraryCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientFullName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientEntries", "LibraryCardId", "dbo.LibraryCards");
            DropForeignKey("dbo.ClientEntries", "BookId", "dbo.Books");
            DropIndex("dbo.ClientEntries", new[] { "BookId" });
            DropIndex("dbo.ClientEntries", new[] { "LibraryCardId" });
            DropTable("dbo.LibraryCards");
            DropTable("dbo.ClientEntries");
            DropTable("dbo.Books");
        }
    }
}
