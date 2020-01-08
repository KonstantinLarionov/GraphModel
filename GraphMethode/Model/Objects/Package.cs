using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMethode.Model.Objects
{
    public enum Protocol 
    {
        TCP,
        UDP,
        FTP,
        HTTP,
        HTTPS,
        PTP,
        LLDP,
        ARP,
        RDP
    }
    public class Package
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Protocol Protocol { get; set; }
        public double Size { get; set; }
        public byte[] Message { get; set; }
    }
}
