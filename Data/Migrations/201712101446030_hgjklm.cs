namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hgjklm : DbMigration
    {
        public override void Up()
        {
            AddColumn("cga.report", "vu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("cga.report", "vu");
        }
    }
}
