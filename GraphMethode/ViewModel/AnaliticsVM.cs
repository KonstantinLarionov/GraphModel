using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GraphMethode.ViewModel
{
    public class AnaliticsVM
    {

        public AnaliticsVM()
        { 
        
        }

        public void ShowPacks(DataGrid data)
        {
            data.ItemsSource = MonitoringVM.Packages;
        }
        public void ShowStepLine()
        { }
    }
}
