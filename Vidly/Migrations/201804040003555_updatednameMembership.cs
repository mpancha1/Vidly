namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatednameMembership : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'PAY AS YOU GO' WHERE ID = 1 ");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'MONTHLY' WHERE ID = 2 ");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'QUARTERLY' WHERE ID = 3 ");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'YEARLY' WHERE ID = 4 ");
        }
        
        public override void Down()
        {
        }
    }
}
