using System;
using System.Collections.Generic;
using MahApps.Metro.Controls;

namespace HYBAP
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : MetroWindow
    {
        public SettingWindow(string strRootDirectory)
        {
            InitializeComponent();

            txtDir.Text = strRootDirectory;
        }
        
        public string RootDirectory
        {
            get
            {
                return txtDir.Text.Trim();
            }
        }
        
        private void Validation_Error(object sender, System.Windows.Controls.ValidationErrorEventArgs e)
        {
        }
        
        private void BtnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(RootDirectory))
            {
                System.Windows.MessageBox.Show("Please, set the working directory.");
                return;
            }

            this.DialogResult = true;
        }
        
        private void BtnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        
        private void BtnPath_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog vistaFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            //vistaFolderBrowserDialog.Description = "Browse folders";
            vistaFolderBrowserDialog.SelectedPath = txtDir.Text;
            //vistaFolderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            vistaFolderBrowserDialog.ShowNewFolderButton = true;

            if (vistaFolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDir.Text = vistaFolderBrowserDialog.SelectedPath;
            }
        }
    }
}

