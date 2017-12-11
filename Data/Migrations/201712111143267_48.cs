namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _48 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "cga.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DTYPE = c.String(nullable: false, maxLength: 31, storeType: "nvarchar"),
                        email = c.String(maxLength: 255, storeType: "nvarchar"),
                        firstName = c.String(maxLength: 255, storeType: "nvarchar"),
                        lastName = c.String(maxLength: 255, storeType: "nvarchar"),
                        password = c.String(maxLength: 255, storeType: "nvarchar"),
                        role = c.String(maxLength: 255, storeType: "nvarchar"),
                        expertiseLevel = c.String(maxLength: 255, storeType: "nvarchar"),
                        phoneNumber = c.String(maxLength: 255, storeType: "nvarchar"),
                        cin1 = c.String(maxLength: 255, storeType: "nvarchar"),
                        cin2 = c.String(maxLength: 255, storeType: "nvarchar"),
                        delivredIn = c.DateTime(precision: 0),
                        driverLicenseNumber = c.Int(),
                        insurance_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "cga.address",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        address = c.String(maxLength: 255, storeType: "nvarchar"),
                        city = c.String(maxLength: 255, storeType: "nvarchar"),
                        government = c.String(maxLength: 255, storeType: "nvarchar"),
                        postalCode = c.Int(),
                        insured_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("cga.user", t => t.user_id)
                .Index(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("cga.address", "user_id", "cga.user");
            DropIndex("cga.address", new[] { "user_id" });
            DropTable("cga.address");
            DropTable("cga.user");
        }
    }
}
