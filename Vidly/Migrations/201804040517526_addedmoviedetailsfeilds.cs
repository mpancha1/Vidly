namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmoviedetailsfeilds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Numinstock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Numinstock");
            DropColumn("dbo.Movies", "AddedDateTime");
            DropColumn("dbo.Movies", "ReleaseDateTime");
        }
    }
}
