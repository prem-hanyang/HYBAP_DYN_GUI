using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;
using Module.Models;

namespace Module.Views
{
    /// <summary>
    /// StaticAndDynamicAnalysis.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StaticAndDynamicAnalysis : UserControl
    {
        public StaticAndDynamicAnalysis()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (o, ea) =>
                {
                    ViewModels.StaticAndDynamicAnalysisViewModel vm = null;
                    Dispatcher.Invoke((Action)(() =>
                        {
                            vm = DataContext as ViewModels.StaticAndDynamicAnalysisViewModel;
                        }
                    ));

                    if (null != vm && null != vm.Data)
                    {
                        ResultInfo output = new ResultInfo();
                        if (SolvingHelper.SolvingExecute(vm.RootDirectory, vm.Data, ref output))
                        {
                            if (false == MeshHelper.ReadMeshResult(vm.RootDirectory, vm.Data))
                                MessageBox.Show("Fail to mesh.");
                            if (false == SolvingHelper.ReadPressureResult(vm.RootDirectory, vm.Data))
                                MessageBox.Show("Fail to solving.");
                            for (int i = 0; i < vm.Data.MainData.PartCount; ++i)
                            {
                                ResultData resPart = new ResultData();
                                resPart.Friction = output.Friction[i];
                                resPart.LoadCapacity = output.LoadCapacity[i];
                                for (int j = 0; j < 25; ++j)
                                    resPart.Stiffness[j] = output.Stiffness[i].value[j];
                                for (int j = 0; j < 25; ++j)
                                    resPart.Damping[j] = output.Damping[i].value[j];
                                vm.Data.MainData.PartList[i].ResultData = resPart;
                            }
                            ResultData resTotal = new ResultData();
                            resTotal.Friction = output.Total_Friction;
                            resTotal.LoadCapacity = double.NaN;
                            if (1 == vm.Data.StaticAndDynamicAnalysisData.SelectAnalysisCase)
                            {
                                resTotal.Stiffness = null;
                                resTotal.Damping = null;
                                resTotal.DynamicResultReady = false;
                            }
                            else if (2 == vm.Data.StaticAndDynamicAnalysisData.SelectAnalysisCase)
                            {
                                for (int j = 0; j < 25; ++j)
                                    resTotal.Stiffness[j] = output.Total_Stiffness.value[j];
                                for (int j = 0; j < 25; ++j)
                                    resTotal.Damping[j] = output.Total_Damping.value[j];
                                resTotal.DynamicResultReady = true;
                            }
                            vm.Data.MainData.ResultData = resTotal;

                            ViewModels.StaticAndDynamicAnalysisResultViewModel.This.Refresh();
                        }
                    }
                };
            bw.RunWorkerCompleted += (o, ea) =>
                {
                    ViewModels.StaticAndDynamicAnalysisViewModel vm = null;
                    Dispatcher.Invoke((Action)(() =>
                    {
                        vm = DataContext as ViewModels.StaticAndDynamicAnalysisViewModel;
                    }
                    ));
                    vm.IsBusy = false;
                    CommandManager.InvalidateRequerySuggested();
                };

            ViewModels.StaticAndDynamicAnalysisViewModel _vm = DataContext as ViewModels.StaticAndDynamicAnalysisViewModel;
            _vm.IsBusy = true;
            bw.RunWorkerAsync();
        }
    }
}
