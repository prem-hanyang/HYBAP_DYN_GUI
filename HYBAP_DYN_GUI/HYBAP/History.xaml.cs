using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HYBAP
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History(string strUrlOSSInfo)
        {
            InitializeComponent();
            labelPlatform.Content = Environment.Is64BitProcess ? "x64" : "x86";
            labelCopyrightYear.Content = File.GetCreationTime(System.Windows.Forms.Application.ExecutablePath).Year.ToString();
            labelProgramDetailedVersion.Content = System.Windows.Forms.Application.ProductVersion;

#if (VM)
            var arVer = labelProgramDetailedVersion.Content.ToString().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(null != arVer && 4 == arVer.Length);
            string strVer = arVer[0];
            if (arVer[1][1] != '0')
            {
                // Service Pack Found
                labelProgramDetailedVersion.Content += string.Format("Service Pack {0}", arVer[1][1]);
            }
            if (arVer[1][0] != '0')
            {
                strVer += string.Format(".{0}", arVer[1][0]);
            }
            labelVersion.Content = strVer;
#endif
            m_fs = File.OpenRead(strUrlOSSInfo);
            browserNotice.NavigateToStream(m_fs);

            //System.Windows.Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            m_fs.Close();
            Close();
        }

        private void ShowSystemInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "msinfo32.exe";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        FileStream m_fs;
    }
}
