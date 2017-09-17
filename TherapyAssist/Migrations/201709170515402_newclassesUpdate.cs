namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newclassesUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patient", "Pateint_ID");
            DropColumn("dbo.Therapist", "Therapist_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Therapist", "Therapist_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Patient", "Pateint_ID", c => c.Int(nullable: false));
        }
    }
}
