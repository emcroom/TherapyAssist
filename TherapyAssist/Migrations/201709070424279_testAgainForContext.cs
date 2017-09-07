namespace TherapyAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testAgainForContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Equipment_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Exercise_Exercise_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Equipment_ID)
                .ForeignKey("dbo.Exercises", t => t.Exercise_Exercise_ID)
                .Index(t => t.Exercise_Exercise_ID);
            
            CreateTable(
                "dbo.ExerciseIntervals",
                c => new
                    {
                        ExerciseInterval_ID = c.Int(nullable: false, identity: true),
                        Repetitions = c.Int(nullable: false),
                        TimesPerDay = c.Int(nullable: false),
                        Exercise_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseInterval_ID)
                .ForeignKey("dbo.Exercises", t => t.Exercise_ID, cascadeDelete: true)
                .Index(t => t.Exercise_ID);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Exercise_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ExerciseType_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Exercise_ID)
                .ForeignKey("dbo.ExerciseTypes", t => t.ExerciseType_ID, cascadeDelete: true)
                .Index(t => t.ExerciseType_ID);
            
            CreateTable(
                "dbo.ExerciseTypes",
                c => new
                    {
                        ExerciseType_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseType_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExerciseIntervals", "Exercise_ID", "dbo.Exercises");
            DropForeignKey("dbo.Exercises", "ExerciseType_ID", "dbo.ExerciseTypes");
            DropForeignKey("dbo.Equipments", "Exercise_Exercise_ID", "dbo.Exercises");
            DropIndex("dbo.Exercises", new[] { "ExerciseType_ID" });
            DropIndex("dbo.ExerciseIntervals", new[] { "Exercise_ID" });
            DropIndex("dbo.Equipments", new[] { "Exercise_Exercise_ID" });
            DropTable("dbo.ExerciseTypes");
            DropTable("dbo.Exercises");
            DropTable("dbo.ExerciseIntervals");
            DropTable("dbo.Equipments");
        }
    }
}
