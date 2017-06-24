using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoTradeDoo.Models
{
    public class AutoTradeDooDb:DbContext
    {
        public AutoTradeDooDb():base("name=DefaultConnection")
        {

        }
        public DbSet<Automobil> automobili { get; set; }
        public DbSet<Novost> novosti { get; set; }
        public DbSet<Newsletter> newsletterLista { get; set; }
    }
}