namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketEntities", "Completed", c => c.Boolean(nullable: false));
            DropColumn("dbo.TicketEntities", "PriorityId");
            DropColumn("dbo.TicketEntities", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketEntities", "Author", c => c.String());
            AddColumn("dbo.TicketEntities", "PriorityId", c => c.Int(nullable: false));
            DropColumn("dbo.TicketEntities", "Completed");
        }
    }
}
