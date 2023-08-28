using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestWinForms.Models.Context
{
    public class Context:DbContext
    {
        public Context()
        :base("name=Context"){ }
        public DbSet<Employees>employees { get; set; }
        public DbSet<Companies> company { get; set; }
    }
}
