using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMethode.Model.Objects
{
    public class Dump
    {
        public int Id { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
    }
}
