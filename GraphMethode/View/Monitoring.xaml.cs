using GraphMethode.Model.Objects;
using GraphMethode.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphMethode.View
{
    /// <summary>
    /// Логика взаимодействия для Monitoring.xaml
    /// </summary>
    public partial class Monitoring : UserControl
    {
        private MonitoringVM VM { get; set; }
        public Monitoring()
        {
            InitializeComponent();
            VM = new MonitoringVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                CheckFileExists = false,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Выберите файл"
            };
            if (dialog.ShowDialog() == true)
            {
                nameFile.Content = dialog.FileName.Split('.')[1] == "pcapng" ? "Корректный" : "Не корректный";
                path.Text = dialog.FileName;
                VM.TakePath(dialog.FileName);
            }
        }


        private void count_KeyUp(object sender, KeyEventArgs e)
        {
            ips.Items.Clear();
            List<Peer> peers = new List<Peer>();
            for (int i = 0; i < Convert.ToInt32(count.Text); i++)
            {
                peers.Add(new Peer() { IP = "0.0.0.0", LastDate = DateTime.Now });
            }
            ips.ItemsSource = peers;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            countAll.Content = count.Text;
            VM.TakeAllEntries(countFound, ips.ItemsSource as List<Peer>);
        }
    }
}
