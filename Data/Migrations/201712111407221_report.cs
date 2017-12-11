namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report : DbMigration
    {
        public override void Up()
        {
            AddColumn("cga.report", "name", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AddColumn("cga.report", "lastName", c => c.String(maxLength: 255, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("cga.report", "lastName");
            DropColumn("cga.report", "name");
        }
    }
}
