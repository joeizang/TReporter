namespace TripodReporter.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RedoPolicyType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PolicyTypes", "PolicyTypeId", "dbo.Policies");
            DropIndex("dbo.PolicyTypes", new[] { "PolicyTypeId" });
            //AddColumn("dbo.Policies", "PolicyType", c => c.Int(nullable: false));
            //DropColumn("dbo.Policies", "PolicyType");
            //DropColumn("dbo.Policies", "PolicyTypeId");
            DropTable("dbo.PolicyTypes");
        }
        
        public override void Down()
        {
        //    CreateTable(
        //        "dbo.PolicyTypes",
        //        c => new
        //            {
        //                PolicyTypeId = c.Int(nullable: false),
        //                TypeName = c.String(nullable: false),
        //                ComissionRates = c.Double(nullable: false),
        //                PolicyId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.PolicyTypeId);

        //    AddColumn("dbo.Policies", "PolicyTypeId", c => c.Int(nullable: false));
        //    DropColumn("dbo.Policies", "PolicyType");
        //    CreateIndex("dbo.PolicyTypes", "PolicyTypeId");
        //    AddForeignKey("dbo.PolicyTypes", "PolicyTypeId", "dbo.Policies", "PolicyId");
        }
    }
}
