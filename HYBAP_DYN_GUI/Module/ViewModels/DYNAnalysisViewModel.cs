using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using Module.Models;
using Module.ViewModels;

using System;
using System.Diagnostics;
using System.Windows.Input;




namespace Module.ViewModels
{
    public class DYNAnalysisViewModel : BindableBase
    {
        private static DYNAnalysisViewModel g_this;
        public static DYNAnalysisViewModel This
        {
            get { return g_this; }
        }

        private DYNAnalysisData m_Data;

        public DYNAnalysisViewModel()
            : base()
        {
            g_this = this;
        }
        public DYNAnalysisData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("AxialDistanceGasForceFromMC");
                base.RaisePropertyChanged("CycleNumber");
                base.RaisePropertyChanged("AngleDivision");
                base.RaisePropertyChanged("InitialConditionX");
                base.RaisePropertyChanged("InitialConditionY");
                base.RaisePropertyChanged("InitialConditionTX");
                base.RaisePropertyChanged("InitialConditionTY");
                base.RaisePropertyChanged("InitialConditionDX");
                base.RaisePropertyChanged("InitialConditionDY");
                base.RaisePropertyChanged("InitialConditionDTX");
                base.RaisePropertyChanged("InitialConditionDTY");
            }
        }

        #region Open
         

        private ICommand m_OpenCommand = null;
        public ICommand OpenCommand
        {
            get
            {
                if (null == m_OpenCommand)
                {
                    m_OpenCommand = new RelayCommand(ExecuteOpenCommand, CanOpenCommandExecute);
                }
                return m_OpenCommand;
            }
        }
        private void OpenCore(string strFilePath)
        {
            XmlSerializer reader = null;
            System.IO.StreamReader file = null;
            reader = new XmlSerializer(typeof(InputData));
            //try
            //{
            //    file = new System.IO.StreamReader(strFilePath);
            //    InputData = (InputData)reader.Deserialize(file);
            //}
            //finally
            //{
            //    if (null != file)
            //        file.Close();
            //}

            //MainViewModel.This.Data = InputData.MainData;
            //PartViewModel.This.Data = InputData.MainData;
            ////RecirculationChannelViewModel.This.Data = InputData.RecirculationChannelData;
            //MeshViewModel.This.Data = InputData;
            //RootDirectory = RootDirectory;
            //DYNViewModel.This.Data = InputData.DYNData;
            //DYNAnalysisViewModel.This.Data = InputData.DYNAnalysisData;
            ////StaticAndDynamicAnalysisViewModel.This.Data = InputData;
            ////MeshAndPressurePlotViewModel.This.Data = InputData;
            //StaticAndDynamicAnalysisResultViewModel.This.Data = InputData.MainData;
            ////DAFULViewModel.This.Data = InputData.DAFULData;

            //CurrentFileName = System.IO.Path.GetFileName(strFilePath);
        }
        private void ExecuteOpenCommand(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = RootDirectory;
            dlg.Filter = "Gas force File (*.dat)|*.dat";
            if (true == dlg.ShowDialog())
                OpenCore(dlg.FileName);
        }
        private bool CanOpenCommandExecute(object obj)
        {
            return IsIdle;
        }
        public string RootDirectory
        {
            get;
            set;
        }
        public bool IsIdle
        {
            get
            {
                if (null != MeshViewModel.This)
                {
                    if (true == MeshViewModel.This.IsBusy)
                    {
                        if (IsEnableTab)
                            IsEnableTab = false;
                        return false;
                    }
                }

                if (null != StaticAndDynamicAnalysisViewModel.This)
                {
                    if (true == StaticAndDynamicAnalysisViewModel.This.IsBusy)
                    {
                        if (IsEnableTab)
                            IsEnableTab = false;
                        return false;
                    }
                }

                if (!IsEnableTab)
                    IsEnableTab = true;
                return true;
            }
        }
        private bool m_IsEnableTab;
        public bool IsEnableTab
        {
            get { return m_IsEnableTab; }
            set
            {
                m_IsEnableTab = value;
                this.RaisePropertyChanged("IsEnableTab");
            }
        }
        #endregion




        public string HeaderInfo
        {
            get { return "DYNAnalysis"; }
        }

        public double AxialDistanceGasForceFromMC
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AxialDistanceGasForceFromMC;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AxialDistanceGasForceFromMC)
                    return;

                m_Data.AxialDistanceGasForceFromMC = value;

                base.RaisePropertyChanged("AxialDistanceGasForceFromMC");
            }
        }
        public double CycleNumber
        {
            get
            {
                if (null != m_Data)
                    return m_Data.CycleNumber;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.CycleNumber)
                    return;

                m_Data.CycleNumber = value;

                base.RaisePropertyChanged("CycleNumber");
            }
        }
        public double AngleDivision
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AngleDivision;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AngleDivision)
                    return;

                m_Data.AngleDivision = value;

                base.RaisePropertyChanged("AngleDivision");
            }
        }
        public double InitialConditionX
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionX;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionX)
                    return;

                m_Data.InitialConditionX = value;

                base.RaisePropertyChanged("InitialConditionX");
            }
        }
        public double InitialConditionY
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionY;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionY)
                    return;

                m_Data.InitialConditionY = value;

                base.RaisePropertyChanged("InitialConditionY");
            }
        }
        public double InitialConditionTX
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionTX;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionTX)
                    return;

                m_Data.InitialConditionTX = value;

                base.RaisePropertyChanged("InitialConditionTX");
            }
        }
        public double InitialConditionTY
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionTY;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionTY)
                    return;

                m_Data.InitialConditionTY = value;

                base.RaisePropertyChanged("InitialConditionTY");
            }
        }
        public double InitialConditionDX
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionDX;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionDX)
                    return;

                m_Data.InitialConditionDX = value;

                base.RaisePropertyChanged("InitialConditionDX");
            }
        }
        public double InitialConditionDY
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionDY;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionDY)
                    return;

                m_Data.InitialConditionDY = value;

                base.RaisePropertyChanged("InitialConditionDY");
            }
        }
        public double InitialConditionDTX
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionDTX;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionDTX)
                    return;

                m_Data.InitialConditionDTX = value;

                base.RaisePropertyChanged("InitialConditionDTX");
            }
        }
        public double InitialConditionDTY
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InitialConditionDTY;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InitialConditionDTY)
                    return;

                m_Data.InitialConditionDTY = value;

                base.RaisePropertyChanged("InitialConditionDTY");
            }
        }
    }
}

