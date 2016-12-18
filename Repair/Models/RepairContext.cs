using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repair.Models
{
    public class RepairContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RepairContext() : base("name=RepairContext")
        {
        }

        public System.Data.Entity.DbSet<Repair.Models.repair> repairs { get; set; }

        public System.Data.Entity.DbSet<Repair.Models.student> students { get; set; }

        public System.Data.Entity.DbSet<Repair.Models.employee> employees { get; set; }
    }
}
