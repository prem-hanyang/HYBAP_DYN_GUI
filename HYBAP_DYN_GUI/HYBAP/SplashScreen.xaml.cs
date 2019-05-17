using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace HYBAP
{
    /// <summary>
    /// Interaction logic for SplashScreeen.xaml
    /// </summary>
    public partial class SplashScreeen : MetroWindow
    {
        public SplashScreeen()
        {
            InitializeComponent();
        }

        private void Move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
        private void Grid_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Close();
        }
    }
}
