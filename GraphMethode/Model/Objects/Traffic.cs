using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMethode.Model.Objects
{
    public class Traffic
    {
        public int Id { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();
        public Protocol Protocol { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateStop { get; set; }
        public string NameStamp { get; set; }
    }
}
