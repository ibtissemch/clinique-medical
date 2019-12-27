using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Projetcliniquemedical.Models
{
    public class OurDbContext:DbContext
    {
        public OurDbContext() : base("conn")
        {

        }
       
        public DbSet<User> userAccount { get; set; }
        public DbSet<Rdv> rdv { get; set; }
        public DbSet<Patient> patient{ get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}