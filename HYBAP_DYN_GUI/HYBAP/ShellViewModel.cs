using System;
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
using Prism.Commands;
using Prism.Mvvm;
using Module.Models;
using Module.ViewModels;

namespace HYBAP
{
    public class ShellViewModel : BindableBase
    {
        #region New

        private ICommand m_NewCommand = null;
        public ICommand NewCommand
        {
            get
            {
                if (null == m_NewCommand)
                {
                    m_NewCommand = new RelayCommand(ExecuteNewCommand, CanNewCommandExecute);
                }
                return m_NewCommand;
            }
        }
        private void ExecuteNewCommand(object obj)
        {
            InputData = new InputData();
            MainViewModel.This.Data = InputData.MainData;
            MainViewModel.This.PartCount = 2;
            PartViewModel.This.Data = InputData.MainData;
            //RecirculationChannelViewModel.This.Data = InputData.RecirculationChannelData;
            MeshViewModel.This.Data = InputData;
            RootDirectory = RootDirectory;
            DYNViewModel.This.Data = InputData.DYNData;
            DYNAnalysisViewModel.This.Data = InputData.DYNAnalysisData;
            //StaticAndDynamicAnalysisViewModel.This.Data = InputData;
            //MeshAndPressurePlotViewModel.This.Data = InputData;
            StaticAndDynamicAnalysisResultViewModel.This.Data = InputData.MainData;
            //DAFULViewModel.This.Data = InputData.DAFULData;

            CurrentFileName = GetNewFileName();
        }
        private bool CanNewCommandExecute(object obj)
        {
            return IsIdle;
        }

        #endregion

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
            try
            {
                file = new System.IO.StreamReader(strFilePath);
                InputData = (InputData)reader.Deserialize(file);
            }
            finally
            {
                if (null != file)
                    file.Close();
            }

            MainViewModel.This.Data = InputData.MainData;
            PartViewModel.This.Data = InputData.MainData;
            //RecirculationChannelViewModel.This.Data = InputData.RecirculationChannelData;
            MeshViewModel.This.Data = InputData;
            RootDirectory = RootDirectory;
            DYNViewModel.This.Data = InputData.DYNData;
            DYNAnalysisViewModel.This.Data = InputData.DYNAnalysisData;
            //StaticAndDynamicAnalysisViewModel.This.Data = InputData;
            //MeshAndPressurePlotViewModel.This.Data = InputData;
            StaticAndDynamicAnalysisResultViewModel.This.Data = InputData.MainData;
            //DAFULViewModel.This.Data = InputData.DAFULData;

            CurrentFileName = System.IO.Path.GetFileName(strFilePath);
        }
        private void ExecuteOpenCommand(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = RootDirectory;
            dlg.Filter = "HYBAP File (*.hybap)|*.hybap";
            if (true == dlg.ShowDialog())
                OpenCore(dlg.FileName);
        }
        private bool CanOpenCommandExecute(object obj)
        {
            return IsIdle;
        }

        #endregion

        #region Save

        private ICommand m_SaveCommand = null;
        public ICommand SaveCommand
        {
            get
            {
                if (null == m_SaveCommand)
                {
                    m_SaveCommand = new RelayCommand(ExecuteSaveCommand, CanSaveCommandExecute);
                }
                return m_SaveCommand;
            }
        }
        private void SaveCore(string strFilePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(InputData));
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                serializer.Serialize(stream, InputData);
                stream.Position = 0;
                using (System.IO.TextReader tr = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
                {
                    xmlDocument.Load(tr);
                    xmlDocument.Save(strFilePath);
                    tr.Close();
                }
                stream.Close();
            }
        }
        private void ExecuteSaveCommand(object obj)
        {
            SaveCore(System.IO.Path.Combine(RootDirectory, CurrentFileName));
        }
        private bool CanSaveCommandExecute(object obj)
        {
            if (!IsIdle)
                return false;

            return null != InputData;
        }

        #endregion

        #region SaveAs

        private ICommand m_SaveAsCommand = null;
        public ICommand SaveAsCommand
        {
            get
            {
                if (null == m_SaveAsCommand)
                {
                    m_SaveAsCommand = new RelayCommand(ExecuteSaveAsCommand, CanSaveAsCommandExecute);
                }
                return m_SaveAsCommand;
            }
        }
        private void ExecuteSaveAsCommand(object obj)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = RootDirectory;
            dlg.Filter = "HYBAP File (*.hybap)|*.hybap";
            dlg.FileName = CurrentFileName;
            if (true == dlg.ShowDialog())
            {
                SaveCore(dlg.FileName);
                RootDirectory = System.IO.Path.GetDirectoryName(dlg.FileName);
                CurrentFileName = System.IO.Path.GetFileName(dlg.FileName);
            }
        }
        private bool CanSaveAsCommandExecute(object obj)
        {
            bool bResult = false;

            if (!IsIdle)
                bResult = false;
            else
                bResult = null != InputData;

            if (null != DAFULViewModel.This)
            {
                if (bResult && false == DAFULViewModel.This.IsExportBasicInfo_Click)
                {
                    DAFULViewModel.This.ExportBasicInfo_Click += new DAFULViewModel.ButtonClickCommand(ExecuteSaveAsCommand);
                    DAFULViewModel.This.IsExportBasicInfo_Click = true;
                }
                else if (!bResult && true == DAFULViewModel.This.IsExportBasicInfo_Click)
                {
                    DAFULViewModel.This.ExportBasicInfo_Click -= new DAFULViewModel.ButtonClickCommand(ExecuteSaveAsCommand);
                    DAFULViewModel.This.IsExportBasicInfo_Click = false;
                }
            }

            return bResult;
        }

        #endregion

        #region Setting

        private ICommand m_SettingCommand = null;
        public ICommand SettingCommand
        {
            get
            {
                if (null == m_SettingCommand)
                {
                    m_SettingCommand = new RelayCommand(ExecuteSettingCommand, CanSettingCommandExecute);
                }
                return m_SettingCommand;
            }
        }
        private void ExecuteSettingCommand(object obj)
        {
            SettingWindow setting = new SettingWindow(RootDirectory);
            setting.ShowDialog();
            if (true == setting.DialogResult)
                RootDirectory = setting.RootDirectory;

        }
        private bool CanSettingCommandExecute(object obj)
        {
            return IsIdle;
        }

        #endregion

        #region Exit

        private ICommand m_ExitCommand = null;
        public ICommand ExitCommand
        {
            get
            {
                if (null == m_ExitCommand)
                {
                    m_ExitCommand = new RelayCommand(ExecuteExitCommand, CanExitCommandExecute);
                }
                return m_ExitCommand;
            }
        }
        private void ExecuteExitCommand(object obj)
        {
            Application.Current.Shutdown();
        }
        private bool CanExitCommandExecute(object obj)
        {
            return true;
        }

        #endregion

        #region History

        private ICommand m_HistoryCommand = null;
        public ICommand HistoryCommand
        {
            get
            {
                if (null == m_HistoryCommand)
                {
                    m_HistoryCommand = new RelayCommand(ExecuteHistoryCommand, CanHistoryCommandExecute);
                }
                return m_HistoryCommand;
            }
        }
        private void ExecuteHistoryCommand(object obj)
        {
            string strDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string strFilePath = System.IO.Path.Combine(strDir, HYBAP.Properties.Settings.Default.CopyrightAndOSSLicenseInfoPath);
            strFilePath = System.IO.Path.GetFullPath(strFilePath);

            History history = new History(strFilePath);
            history.ShowDialog();
        }
        private bool CanHistoryCommandExecute(object obj)
        {
            string strDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string strFilePath = System.IO.Path.Combine(strDir, HYBAP.Properties.Settings.Default.CopyrightAndOSSLicenseInfoPath);
            strFilePath = System.IO.Path.GetFullPath(strFilePath);

            return System.IO.File.Exists(strFilePath);
        }

        #endregion

        public ShellViewModel()
        {
            if (string.IsNullOrEmpty(RootDirectory))
            {
                RootDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HYBAP");
            }

            if (System.IO.Directory.Exists(RootDirectory) == false)
            {
                System.IO.Directory.CreateDirectory(RootDirectory);
            }
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

        public string RootDirectory
        {
            get { return HYBAP.Properties.Settings.Default.WorkDirectory; }
            set
            {
                HYBAP.Properties.Settings.Default.WorkDirectory = value;
                HYBAP.Properties.Settings.Default.Save();
                this.RaisePropertyChanged("RootDirectory");
                if (null != MeshViewModel.This)
                    MeshViewModel.This.RootDirectory = value;
                if (null != StaticAndDynamicAnalysisViewModel.This)
                    StaticAndDynamicAnalysisViewModel.This.RootDirectory = value;
            }
        }

        public string CurrentFileName
        {
            get;
            set;
        }

        public InputData InputData
        {
            get;
            set;
        }

        public string GetNewFileName()
        {
            string strFileName = "Model";
            int nIndex = 0;
            while (System.IO.File.Exists(System.IO.Path.Combine(RootDirectory, strFileName + ".hybap")))
            {
                strFileName = string.Format("Model ({0})", ++nIndex);
            }
            return strFileName + ".hybap";
        }

        public void RelayKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (null != MeshViewModel.This && null != MeshViewModel.This.ActiveView)
            {
                switch (e.Key)
                {
                    case Key.Q:
                        MeshViewModel.This.z += 0.5;
                        break;
                    case Key.E:
                        MeshViewModel.This.z -= 0.5;
                        break;
                    case Key.W:
                        MeshViewModel.This.y += 0.5;
                        break;
                    case Key.S:
                        MeshViewModel.This.y -= 0.5;
                        break;
                    case Key.D:
                        MeshViewModel.This.x += 0.5;
                        break;
                    case Key.A:
                        MeshViewModel.This.x -= 0.5;
                        break;
                }
            }
            else if (null != MeshAndPressurePlotViewModel.This)
            {
                if (null != MeshAndPressurePlotViewModel.This.ActiveMeshView)
                {
                    switch (e.Key)
                    {
                        case Key.Q:
                            MeshAndPressurePlotViewModel.This.z += 0.5;
                            break;
                        case Key.E:
                            MeshAndPressurePlotViewModel.This.z -= 0.5;
                            break;
                        case Key.W:
                            MeshAndPressurePlotViewModel.This.y += 0.5;
                            break;
                        case Key.S:
                            MeshAndPressurePlotViewModel.This.y -= 0.5;
                            break;
                        case Key.D:
                            MeshAndPressurePlotViewModel.This.x += 0.5;
                            break;
                        case Key.A:
                            MeshAndPressurePlotViewModel.This.x -= 0.5;
                            break;
                    }
                }
                else if (null != MeshAndPressurePlotViewModel.This.ActivePressureView)
                {
                    switch (e.Key)
                    {
                        case Key.Q:
                            MeshAndPressurePlotViewModel.This.z_p += 0.5;
                            break;
                        case Key.E:
                            MeshAndPressurePlotViewModel.This.z_p -= 0.5;
                            break;
                        case Key.W:
                            MeshAndPressurePlotViewModel.This.y_p += 0.5;
                            break;
                        case Key.S:
                            MeshAndPressurePlotViewModel.This.y_p -= 0.5;
                            break;
                        case Key.D:
                            MeshAndPressurePlotViewModel.This.x_p += 0.5;
                            break;
                        case Key.A:
                            MeshAndPressurePlotViewModel.This.x_p -= 0.5;
                            break;
                    }
                }
            }
        }

        public void RelayMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            if (null != MeshViewModel.This.ActiveView && null != MeshViewModel.This.ActiveView)
            {
                Point pt = e.GetPosition(MeshViewModel.This.ActiveView);
                MeshViewModel.This.CursorX = pt.X;
                MeshViewModel.This.CursorY = pt.Y;
            }
            else if (null != MeshAndPressurePlotViewModel.This)
            {
                if (null != MeshAndPressurePlotViewModel.This.ActiveMeshView)
                {
                    Point pt = e.GetPosition(MeshAndPressurePlotViewModel.This.ActiveMeshView);
                    MeshAndPressurePlotViewModel.This.CursorX = pt.X;
                    MeshAndPressurePlotViewModel.This.CursorY = pt.Y;
                }
                else if (null != MeshAndPressurePlotViewModel.This.ActivePressureView)
                {
                    Point pt = e.GetPosition(MeshAndPressurePlotViewModel.This.ActivePressureView);
                    MeshAndPressurePlotViewModel.This.CursorX_p = pt.X;
                    MeshAndPressurePlotViewModel.This.CursorY_p = pt.Y;
                }
            }
        }

        public void RelayMouseButtonStatus(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (null != MeshViewModel.This.ActiveView && null != MeshViewModel.This.ActiveView)
            {
                if (MouseButton.Left == e.ChangedButton)
                {
                    if (MouseButtonState.Pressed == e.ButtonState)
                        MeshViewModel.This.isLClicked = true;
                    else if (MouseButtonState.Released == e.ButtonState)
                        MeshViewModel.This.isLClicked = false;
                }
                else if (MouseButton.Right == e.ChangedButton)
                {
                    if (MouseButtonState.Pressed == e.ButtonState)
                        MeshViewModel.This.isRClicked = true;
                    else if (MouseButtonState.Released == e.ButtonState)
                        MeshViewModel.This.isRClicked = false;
                }
            }
            else if (null != MeshAndPressurePlotViewModel.This)
            {
                if (null != MeshAndPressurePlotViewModel.This.ActiveMeshView)
                {
                    if (MouseButton.Left == e.ChangedButton)
                    {
                        if (MouseButtonState.Pressed == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isLClicked = true;
                        else if (MouseButtonState.Released == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isLClicked = false;
                    }
                    else if (MouseButton.Right == e.ChangedButton)
                    {
                        if (MouseButtonState.Pressed == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isRClicked = true;
                        else if (MouseButtonState.Released == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isRClicked = false;
                    }
                }
                else if (null != MeshAndPressurePlotViewModel.This.ActivePressureView)
                {
                    if (MouseButton.Left == e.ChangedButton)
                    {
                        if (MouseButtonState.Pressed == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isLClicked_p = true;
                        else if (MouseButtonState.Released == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isLClicked_p = false;
                    }
                    else if (MouseButton.Right == e.ChangedButton)
                    {
                        if (MouseButtonState.Pressed == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isRClicked_p = true;
                        else if (MouseButtonState.Released == e.ButtonState)
                            MeshAndPressurePlotViewModel.This.isRClicked_p = false;
                    }
                }
            }
        }
    }
}
