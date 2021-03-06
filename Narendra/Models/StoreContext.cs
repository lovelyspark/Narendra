using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Narendra.Models
{
    public class StoreContext : DbContext
    {
     
        public DbSet<Register> Registers { get; set; }
       
    }
}