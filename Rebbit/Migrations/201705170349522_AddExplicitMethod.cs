namespace Rebbit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExplicitMethod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Postzs", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Postzs", "UserId");
            AddForeignKey("dbo.Postzs", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postzs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Postzs", new[] { "UserId" });
            AlterColumn("dbo.Postzs", "UserId", c => c.String());
        }
    }
}
