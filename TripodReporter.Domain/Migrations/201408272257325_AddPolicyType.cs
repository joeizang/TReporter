namespace TripodReporter.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPolicyType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PolicyTypes",
                c => new
                    {
                        PolicyTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        ComissionRates = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PolicyTypeId);
            
            AddColumn("dbo.Policies", "PolicyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Policies", "PolicyTypeId");
            //AddForeignKey("dbo.Policies", "PolicyTypeId", "dbo.PolicyTypes", "PolicyTypeId", cascadeDelete: true);
            //had to remove the above line in order to update the database properly using migrations
            DropColumn("dbo.Policies", "PolicyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Policies", "PolicyType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Policies", "PolicyTypeId", "dbo.PolicyTypes");
            DropIndex("dbo.Policies", new[] { "PolicyTypeId" });
            DropColumn("dbo.Policies", "PolicyTypeId");
            DropTable("dbo.PolicyTypes");
        }
    }
}
