namespace Projetcliniquemedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medecins",
                c => new
                    {
                        MedecinID = c.Int(nullable: false, identity: true),
                        MedecinNom = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedecinID)
                .ForeignKey("dbo.UserAccounts", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientNom = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.UserAccounts", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Rdvs",
                c => new
                    {
                        RdvID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Hdebut = c.DateTime(nullable: false),
                        Hfin = c.DateTime(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RdvID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rdvs", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Patients", "UserID", "dbo.UserAccounts");
            DropForeignKey("dbo.Medecins", "UserID", "dbo.UserAccounts");
            DropIndex("dbo.Rdvs", new[] { "PatientID" });
            DropIndex("dbo.Patients", new[] { "UserID" });
            DropIndex("dbo.Medecins", new[] { "UserID" });
            DropTable("dbo.Rdvs");
            DropTable("dbo.Patients");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Medecins");
        }
    }
}
