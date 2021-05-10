namespace TE29_HeartHealth_GCardiac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FamilyMember", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FamilyMember", "UserId", c => c.Int(nullable: false));
        }
    }
}
