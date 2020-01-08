using GraphMethode.Model.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMethode.Model.Entitys
{
    public class ReaderContext : DbContext
    {
        public ReaderContext() : base("Graph") { }
        public DbSet<Package> Packages { get; private set; }
        public DbSet<Dump> Dumps { get; private set; }
        public DbSet<Traffic> Traffics { get; private set; }
    }
}
