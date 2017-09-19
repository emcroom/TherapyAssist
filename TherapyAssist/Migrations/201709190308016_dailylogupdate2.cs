namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dailylogupdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID", "dbo.DailyLogs");
            DropIndex("dbo.ExerciseIntervals", new[] { "DailyLog_DailyLog_ID" });
            AddColumn("dbo.DailyLogs", "MyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DailyLogs", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.DailyLogs", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.PatientExercises", "CreatedBy", c => c.Int(nullable: false));
            DropColumn("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID", c => c.Int());
            AlterColumn("dbo.PatientExercises", "CreatedBy", c => c.String());
            AlterColumn("dbo.DailyLogs", "ModifiedBy", c => c.String());
            AlterColumn("dbo.DailyLogs", "CreatedBy", c => c.String());
            DropColumn("dbo.DailyLogs", "MyDate");
            CreateIndex("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID");
            AddForeignKey("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID", "dbo.DailyLogs", "DailyLog_ID");
        }
    }
}
