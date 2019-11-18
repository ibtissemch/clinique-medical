namespace Projetcliniquemedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rdvs", "MedecinID", c => c.Int(nullable: true));
            CreateIndex("dbo.Rdvs", "MedecinID");
            AddForeignKey("dbo.Rdvs", "MedecinID", "dbo.Medecins", "MedecinID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rdvs", "MedecinID", "dbo.Medecins");
            DropIndex("dbo.Rdvs", new[] { "MedecinID" });
            DropColumn("dbo.Rdvs", "MedecinID");
        }
    }
}
