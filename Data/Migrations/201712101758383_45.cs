namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _45 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("cga.report", "vu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("cga.report", "vu", c => c.Boolean(nullable: false));
        }
    }
}
