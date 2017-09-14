namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyLogs",
                c => new
                    {
                        DailyLog_ID = c.Int(nullable: false, identity: true),
                        User_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DailyLog_ID)
                .ForeignKey("dbo.UserDetails", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.PatientExercises",
                c => new
                    {
                        PatientExercise_ID = c.Int(nullable: false, identity: true),
                        Exercise_ID = c.Int(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                        CompletedDateTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Patient_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PatientExercise_ID)
                .ForeignKey("dbo.Exercises", t => t.Exercise_ID, cascadeDelete: true)
                .ForeignKey("dbo.UserDetails", t => t.Patient_User_ID)
                .Index(t => t.Exercise_ID)
                .Index(t => t.Patient_User_ID);
            
            CreateTable(
                "dbo.TherapistPatients",
                c => new
                    {
                        Therapist_User_ID = c.Int(nullable: false),
                        Patient_User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Therapist_User_ID, t.Patient_User_ID })
                .ForeignKey("dbo.UserDetails", t => t.Therapist_User_ID)
                .ForeignKey("dbo.UserDetails", t => t.Patient_User_ID)
                .Index(t => t.Therapist_User_ID)
                .Index(t => t.Patient_User_ID);
            
            AddColumn("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID", c => c.Int());
            AddColumn("dbo.UserDetails", "Pateint_ID", c => c.Int());
            AddColumn("dbo.UserDetails", "isPhysicalTherapy", c => c.Boolean());
            AddColumn("dbo.UserDetails", "isOccupationalTherapy", c => c.Boolean());
            AddColumn("dbo.UserDetails", "isSpeechTherapy", c => c.Boolean());
            AddColumn("dbo.UserDetails", "Therapist_ID", c => c.Int());
            AddColumn("dbo.UserDetails", "MedicalInstitutionName", c => c.String());
            AddColumn("dbo.UserDetails", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID");
            AddForeignKey("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID", "dbo.DailyLogs", "DailyLog_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyLogs", "User_ID", "dbo.UserDetails");
            DropForeignKey("dbo.TherapistPatients", "Patient_User_ID", "dbo.UserDetails");
            DropForeignKey("dbo.TherapistPatients", "Therapist_User_ID", "dbo.UserDetails");
            DropForeignKey("dbo.PatientExercises", "Patient_User_ID", "dbo.UserDetails");
            DropForeignKey("dbo.PatientExercises", "Exercise_ID", "dbo.Exercises");
            DropForeignKey("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID", "dbo.DailyLogs");
            DropIndex("dbo.TherapistPatients", new[] { "Patient_User_ID" });
            DropIndex("dbo.TherapistPatients", new[] { "Therapist_User_ID" });
            DropIndex("dbo.PatientExercises", new[] { "Patient_User_ID" });
            DropIndex("dbo.PatientExercises", new[] { "Exercise_ID" });
            DropIndex("dbo.ExerciseIntervals", new[] { "DailyLog_DailyLog_ID" });
            DropIndex("dbo.DailyLogs", new[] { "User_ID" });
            DropColumn("dbo.UserDetails", "Discriminator");
            DropColumn("dbo.UserDetails", "MedicalInstitutionName");
            DropColumn("dbo.UserDetails", "Therapist_ID");
            DropColumn("dbo.UserDetails", "isSpeechTherapy");
            DropColumn("dbo.UserDetails", "isOccupationalTherapy");
            DropColumn("dbo.UserDetails", "isPhysicalTherapy");
            DropColumn("dbo.UserDetails", "Pateint_ID");
            DropColumn("dbo.ExerciseIntervals", "DailyLog_DailyLog_ID");
            DropTable("dbo.TherapistPatients");
            DropTable("dbo.PatientExercises");
            DropTable("dbo.DailyLogs");
        }
    }
}
