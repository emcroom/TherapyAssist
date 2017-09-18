namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intervalNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExerciseIntervals", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExerciseIntervals", "Notes");
        }
    }
}
