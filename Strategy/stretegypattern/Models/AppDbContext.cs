using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace stretegypattern.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Products> Products { get; set; }
    }
}