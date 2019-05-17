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
    /// StaticAndDynamicAnalysisResult.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StaticAndDynamicAnalysisResult : UserControl
    {
        public StaticAndDynamicAnalysisResult()
        {
            InitializeComponent();
        }

        private void rbTotalPartStiffness_Checked(object sender, RoutedEventArgs e)
        {
            if (null == SelectedPartStiffness || null == SelectedPartStiffness.DataContext)
                return;

            StaticAndDynamicAnalysisResultViewModel vm = SelectedPartStiffness.DataContext as StaticAndDynamicAnalysisResultViewModel;
            if (null != vm)
            {
                if (null != vm.Data && null != vm.Data.ResultData)
                    SetStiffness(vm.Data.ResultData.Stiffness);
            }
        }

        private void rbSelectPartStiffness_Checked(object sender, RoutedEventArgs e)
        {
            if (null == SelectedPartStiffness || null == SelectedPartStiffness.DataContext)
                return;

            StaticAndDynamicAnalysisResultViewModel vm = SelectedPartStiffness.DataContext as StaticAndDynamicAnalysisResultViewModel;
            if (null != vm)
            {
                if (-1 == SelectedPartStiffness.SelectedIndex && 0 < SelectedPartStiffness.Items.Count)
                {
                    SetStiffness(null);
                    return;
                }

                Models.ResultData result = vm.Parts[SelectedPartStiffness.SelectedIndex].ResultData;
                if (null != result)
                    SetStiffness(result.Stiffness);
                else
                    SetStiffness(null);
            }
        }

        private void rbTotalPartDamping_Checked(object sender, RoutedEventArgs e)
        {
            if (null == SelectedPartDamping || null == SelectedPartDamping.DataContext)
                return;

            StaticAndDynamicAnalysisResultViewModel vm = SelectedPartDamping.DataContext as StaticAndDynamicAnalysisResultViewModel;
            if (null != vm)
            {
                if (null != vm.Data && null != vm.Data.ResultData)
                    SetDamping(vm.Data.ResultData.Damping);
            }
        }

        private void rbSelectPartDamping_Checked(object sender, RoutedEventArgs e)
        {
            if (null == SelectedPartDamping || null == SelectedPartDamping.DataContext)
                return;

            StaticAndDynamicAnalysisResultViewModel vm = SelectedPartDamping.DataContext as StaticAndDynamicAnalysisResultViewModel;
            if (null != vm)
            {
                if (-1 == SelectedPartDamping.SelectedIndex && 0 < SelectedPartDamping.Items.Count)
                {
                    SetDamping(null);
                    return;
                }

                Models.ResultData result = vm.Parts[SelectedPartDamping.SelectedIndex].ResultData;
                if (null != result)
                    SetDamping(result.Damping);
                else
                    SetDamping(null);
            }
        }

        private void SelectedPartStiffness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rbSelectPartStiffness_Checked(null, null);
        }

        private void SelectedPartDamping_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rbSelectPartDamping_Checked(null, null);
        }

        private void SetStiffness(double[] values)
        {
            if (null == values)
            {
                Kxx.Text = string.Empty;
                Kxy.Text = string.Empty;
                Kxz.Text = string.Empty;
                Kxθx.Text = string.Empty;
                Kxθy.Text = string.Empty;
                Kyx.Text = string.Empty;
                Kyy.Text = string.Empty;
                Kyz.Text = string.Empty;
                Kyθx.Text = string.Empty;
                Kyθy.Text = string.Empty;
                Kzx.Text = string.Empty;
                Kzy.Text = string.Empty;
                Kzz.Text = string.Empty;
                Kzθx.Text = string.Empty;
                Kzθy.Text = string.Empty;
                Kθxx.Text = string.Empty;
                Kθxy.Text = string.Empty;
                Kθxz.Text = string.Empty;
                Kθxθx.Text = string.Empty;
                Kθxθy.Text = string.Empty;
                Kθyx.Text = string.Empty;
                Kθyy.Text = string.Empty;
                Kθyz.Text = string.Empty;
                Kθyθx.Text = string.Empty;
                Kθyθy.Text = string.Empty;
            }
            else
            {
                Kxx.Text = values[0].ToString("0.00e+00");
                Kxy.Text = values[1].ToString("0.00e+00");
                Kxz.Text = values[2].ToString("0.00e+00");
                Kxθx.Text = values[3].ToString("0.00e+00");
                Kxθy.Text = values[4].ToString("0.00e+00");
                Kyx.Text = values[5].ToString("0.00e+00");
                Kyy.Text = values[6].ToString("0.00e+00");
                Kyz.Text = values[7].ToString("0.00e+00");
                Kyθx.Text = values[8].ToString("0.00e+00");
                Kyθy.Text = values[9].ToString("0.00e+00");
                Kzx.Text = values[10].ToString("0.00e+00");
                Kzy.Text = values[11].ToString("0.00e+00");
                Kzz.Text = values[12].ToString("0.00e+00");
                Kzθx.Text = values[13].ToString("0.00e+00");
                Kzθy.Text = values[14].ToString("0.00e+00");
                Kθxx.Text = values[15].ToString("0.00e+00");
                Kθxy.Text = values[16].ToString("0.00e+00");
                Kθxz.Text = values[17].ToString("0.00e+00");
                Kθxθx.Text = values[18].ToString("0.00e+00");
                Kθxθy.Text = values[19].ToString("0.00e+00");
                Kθyx.Text = values[20].ToString("0.00e+00");
                Kθyy.Text = values[21].ToString("0.00e+00");
                Kθyz.Text = values[22].ToString("0.00e+00");
                Kθyθx.Text = values[23].ToString("0.00e+00");
                Kθyθy.Text = values[24].ToString("0.00e+00");
            }
        }

        private void SetDamping(double[] values)
        {
            if (null == values)
            {
                Cxx.Text = string.Empty;
                Cxy.Text = string.Empty;
                Cxz.Text = string.Empty;
                Cxθx.Text = string.Empty;
                Cxθy.Text = string.Empty;
                Cyx.Text = string.Empty;
                Cyy.Text = string.Empty;
                Cyz.Text = string.Empty;
                Cyθx.Text = string.Empty;
                Cyθy.Text = string.Empty;
                Czx.Text = string.Empty;
                Czy.Text = string.Empty;
                Czz.Text = string.Empty;
                Czθx.Text = string.Empty;
                Czθy.Text = string.Empty;
                Cθxx.Text = string.Empty;
                Cθxy.Text = string.Empty;
                Cθxz.Text = string.Empty;
                Cθxθx.Text = string.Empty;
                Cθxθy.Text = string.Empty;
                Cθyx.Text = string.Empty;
                Cθyy.Text = string.Empty;
                Cθyz.Text = string.Empty;
                Cθyθx.Text = string.Empty;
                Cθyθy.Text = string.Empty;
            }
            else
            {
                Cxx.Text = values[0].ToString("0.00e+00");
                Cxy.Text = values[1].ToString("0.00e+00");
                Cxz.Text = values[2].ToString("0.00e+00");
                Cxθx.Text = values[3].ToString("0.00e+00");
                Cxθy.Text = values[4].ToString("0.00e+00");
                Cyx.Text = values[5].ToString("0.00e+00");
                Cyy.Text = values[6].ToString("0.00e+00");
                Cyz.Text = values[7].ToString("0.00e+00");
                Cyθx.Text = values[8].ToString("0.00e+00");
                Cyθy.Text = values[9].ToString("0.00e+00");
                Czx.Text = values[10].ToString("0.00e+00");
                Czy.Text = values[11].ToString("0.00e+00");
                Czz.Text = values[12].ToString("0.00e+00");
                Czθx.Text = values[13].ToString("0.00e+00");
                Czθy.Text = values[14].ToString("0.00e+00");
                Cθxx.Text = values[15].ToString("0.00e+00");
                Cθxy.Text = values[16].ToString("0.00e+00");
                Cθxz.Text = values[17].ToString("0.00e+00");
                Cθxθx.Text = values[18].ToString("0.00e+00");
                Cθxθy.Text = values[19].ToString("0.00e+00");
                Cθyx.Text = values[20].ToString("0.00e+00");
                Cθyy.Text = values[21].ToString("0.00e+00");
                Cθyz.Text = values[22].ToString("0.00e+00");
                Cθyθx.Text = values[23].ToString("0.00e+00");
                Cθyθy.Text = values[24].ToString("0.00e+00");
            }
        }
    }
}
