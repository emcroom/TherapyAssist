namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newclasses1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Pateint_ID = c.Int(nullable: false),
                        isPhysicalTherapy = c.Boolean(nullable: false),
                        isOccupationalTherapy = c.Boolean(nullable: false),
                        isSpeechTherapy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.UserDetails", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Therapist",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Therapist_ID = c.Int(nullable: false),
                        MedicalInstitutionName = c.String(),
                    })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.UserDetails", t => t.User_ID)
                .Index(t => t.User_ID);
            
            DropColumn("dbo.UserDetails", "Pateint_ID");
            DropColumn("dbo.UserDetails", "isPhysicalTherapy");
            DropColumn("dbo.UserDetails", "isOccupationalTherapy");
            DropColumn("dbo.UserDetails", "isSpeechTherapy");
            DropColumn("dbo.UserDetails", "Therapist_ID");
            DropColumn("dbo.UserDetails", "MedicalInstitutionName");
            DropColumn("dbo.UserDetails", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UserDetails", "MedicalInstitutionName", c => c.String());
            AddColumn("dbo.UserDetails", "Therapist_ID", c => c.Int());
            AddColumn("dbo.UserDetails", "isSpeechTherapy", c => c.Boolean());
            AddColumn("dbo.UserDetails", "isOccupationalTherapy", c => c.Boolean());
            AddColumn("dbo.UserDetails", "isPhysicalTherapy", c => c.Boolean());
            AddColumn("dbo.UserDetails", "Pateint_ID", c => c.Int());
            DropForeignKey("dbo.Therapist", "User_ID", "dbo.UserDetails");
            DropForeignKey("dbo.Patient", "User_ID", "dbo.UserDetails");
            DropIndex("dbo.Therapist", new[] { "User_ID" });
            DropIndex("dbo.Patient", new[] { "User_ID" });
            DropTable("dbo.Therapist");
            DropTable("dbo.Patient");
        }
    }
}
