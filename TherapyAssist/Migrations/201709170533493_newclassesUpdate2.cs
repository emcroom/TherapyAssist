namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newclassesUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientExercises", "Exercise_ID", "dbo.Exercises");
            DropIndex("dbo.PatientExercises", new[] { "Exercise_ID" });
            AddColumn("dbo.ExerciseIntervals", "PatientExercise_ID", c => c.Int(nullable: false));
            AddColumn("dbo.PatientExercises", "ExerciseInterval_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientExercises", "ExerciseInterval_ID");
            AddForeignKey("dbo.PatientExercises", "ExerciseInterval_ID", "dbo.ExerciseIntervals", "ExerciseInterval_ID", cascadeDelete: true);
            DropColumn("dbo.PatientExercises", "Exercise_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientExercises", "Exercise_ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.PatientExercises", "ExerciseInterval_ID", "dbo.ExerciseIntervals");
            DropIndex("dbo.PatientExercises", new[] { "ExerciseInterval_ID" });
            DropColumn("dbo.PatientExercises", "ExerciseInterval_ID");
            DropColumn("dbo.ExerciseIntervals", "PatientExercise_ID");
            CreateIndex("dbo.PatientExercises", "Exercise_ID");
            AddForeignKey("dbo.PatientExercises", "Exercise_ID", "dbo.Exercises", "Exercise_ID", cascadeDelete: true);
        }
    }
}
