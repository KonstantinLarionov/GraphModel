using GraphMethode.View;
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

namespace GraphMethode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Monitoring monitor { get; set; }
        private Analitics analitics { get; set; }
        private Building building { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "monitoring":
                    monitor = new Monitoring();
                    mainPanel.Children.Clear();
                    mainPanel.Children.Add(monitor);
                    break;
                case "analitic":
                    analitics = new Analitics();
                    mainPanel.Children.Clear();
                    mainPanel.Children.Add(analitics);
                    break;
                case "build":
                    building = new Building();
                    mainPanel.Children.Clear();
                    mainPanel.Children.Add(building);
                    break;
                default:
                    break;
            }
        }
    }
}
