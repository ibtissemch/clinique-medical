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
        public DbSet<UserAccount> userAccount { get; set; }
    }
}