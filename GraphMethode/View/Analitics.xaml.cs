using GraphMethode.ViewModel;
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
    /// Логика взаимодействия для Analitics.xaml
    /// </summary>
    public partial class Analitics : UserControl
    {
        private AnaliticsVM VM { get; set; }
        public Analitics()
        {
            InitializeComponent();
            VM = new AnaliticsVM();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            VM.ShowPacks(data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MonitoringVM.Packages.OrderBy(x=>x.DateTime);
            VM.ShowStepLine();
        }
    }
}
