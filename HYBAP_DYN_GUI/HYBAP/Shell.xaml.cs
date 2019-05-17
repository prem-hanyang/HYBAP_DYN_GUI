using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace HYBAP
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : MetroWindow
    {
        bool m_bInitTabIndex;

        public Shell()
        {
            m_bInitTabIndex = false;
            InitializeComponent();
        }

        private void MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!m_bInitTabIndex && 6 == MainTab.Items.Count && 5 == MainTab.SelectedIndex)  //if (!m_bInitTabIndex && 8 == MainTab.Items.Count && 7 == MainTab.SelectedIndex) // Ori code
            // MainTab.Items.Count : 전체 tap 개수  // MainTab.SelectedIndex : 전체 tap 개수 - 1
            {
                MainTab.SelectedIndex = 0;
                m_bInitTabIndex = true;
            }
        }

        private void MetroWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            (DataContext as ShellViewModel).RelayKeyDown(e);
        }

        private void MetroWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (DataContext as ShellViewModel).RelayMouseMove(e);
        }

        private void MetroWindow_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (DataContext as ShellViewModel).RelayMouseButtonStatus(e);
        }

        private void MetroWindow_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (DataContext as ShellViewModel).RelayMouseButtonStatus(e);
        }

        private void MetroWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (DataContext as ShellViewModel).RelayMouseButtonStatus(e);
        }

        private void MetroWindow_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (DataContext as ShellViewModel).RelayMouseButtonStatus(e);
        }
    }
}
