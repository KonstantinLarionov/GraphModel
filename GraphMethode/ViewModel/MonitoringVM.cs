using GraphMethode.Model.Entitys;
using GraphMethode.Model.Objects;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GraphMethode.ViewModel
{
    public class MonitoringVM
    {
        private WriterContext db { get; set; }
        private Dump Dump { get; set; }
        public static List<Package> Packages { get; set; } = new List<Package>();
        private string FilePath { get; set; }
        private int I { get; set; }
        public MonitoringVM()
        {
            db = new WriterContext();
            Dump = new Dump();
            I = 0;
        }

        public void TakePath(string file)
        {
            FilePath = file;
        }

        public void TakeAllEntries(Label count, List<Peer> peers)
        {
            GetDump(FilePath);
            I = 0;
            List<Package> packages = new List<Package>();
            foreach (var item in peers)
            {
                var taker = Dump.Packages.Where(x => (x.From == item.IP || x.To == item.IP) && (!Packages.Any(y=>y.Id == x.Id)) ).ToList();
                Packages.AddRange(taker);
            }
            count.Content = Packages.Count.ToString();
        }

        private void GetDump(string file)
        {
            CaptureFileReaderDevice device = new CaptureFileReaderDevice(file);
            device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
            device.Capture();
        }

        private void Device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            try
            {
                var tcpPacket = TcpPacket.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                if (tcpPacket != null)
                {
                    DateTime time = e.Packet.Timeval.Date;
                    int len = e.Packet.Data.Length;
                    var srcIp = tcpPacket.PayloadPacket.ToString();
                    var data = tcpPacket.PayloadPacket.Bytes;
                    var ipSource = srcIp.Split(new string[] { "SourceAddress=" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { ", DestinationAddress=" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    var ipDest = srcIp.Split(new string[] { ", DestinationAddress=" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[0];

                    Dump.Packages.Add(new Package()
                    {
                        DateTime = time,
                        Size = len,
                        Protocol = Protocol.TCP,
                        From = ipSource,
                        To = ipDest,
                        Message = data,
                        Id = I
                    });
                }
                I++;
            }
            catch { }
        }
    }
}
