namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientExercises", "Patient_ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientExercises", "Patient_ID");
        }
    }
}
