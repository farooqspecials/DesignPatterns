using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace TestApp.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<WebsiteMetadata> Metadata { get; set; }
       
    }
}