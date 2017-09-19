namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dailylogupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailyLogs", "User_ID", "dbo.UserDetails");
            AddForeignKey("dbo.DailyLogs", "User_ID", "dbo.Patient", "User_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyLogs", "User_ID", "dbo.Patient");
            AddForeignKey("dbo.DailyLogs", "User_ID", "dbo.UserDetails", "User_ID", cascadeDelete: true);
        }
    }
}
