namespace LibraryManager.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20160701 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LibraryCards", "FullName", c => c.String());
            DropColumn("dbo.LibraryCards", "ClientFullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LibraryCards", "ClientFullName", c => c.String());
            DropColumn("dbo.LibraryCards", "FullName");
        }
    }
}
