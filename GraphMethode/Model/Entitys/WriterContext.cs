using GraphMethode.Model.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMethode.Model.Entitys
{
    public class WriterContext : DbContext
    {
        public WriterContext() : base("Graph") { }
        public DbSet<Package> Packages { private get;  set; }
        public DbSet<Dump> Dumps { private get;  set; }
        public DbSet<Traffic> Traffics { private get;  set; }
    }
}
