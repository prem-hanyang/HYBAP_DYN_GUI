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
using Module.ViewModels;

namespace Module.Views
{
    /// <summary>
    /// Interaction logic for DAFUL.xaml
    /// </summary>
    public partial class DAFUL : UserControl
    {
        public DAFUL()
        {
            InitializeComponent();
        }

        private void ButtonBasicInfo_Click(object sender, RoutedEventArgs e)
        {
            DAFULViewModel vm = DataContext as DAFULViewModel;
            if (null != vm)
                vm.OnExportBasicInfo();
        }

        private void ButtonStiffnessMap_Click(object sender, RoutedEventArgs e)
        {
            DAFULViewModel vm = DataContext as DAFULViewModel;
            if (null != vm)
                vm.OnExportStiffnessMapInfo();
        }
    }
}
