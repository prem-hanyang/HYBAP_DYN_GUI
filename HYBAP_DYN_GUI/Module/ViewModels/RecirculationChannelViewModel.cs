using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class RecirculationChannelViewModel : BindableBase
    {
        private static RecirculationChannelViewModel g_this;
        public static RecirculationChannelViewModel This
        {
            get { return g_this; }
        }

        private RecirculationChannelData m_Data;
        private List<RecirculationChannelInfoViewModel> m_lstRecirculationChannelInfoViewModel;

        public RecirculationChannelViewModel()
            : base()
        {
            g_this = this;
        }

        public RecirculationChannelData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("Density");
                base.RaisePropertyChanged("RecirculationChannelInfoCount");
                base.RaisePropertyChanged("RecirculationChannelInfos");
                base.RaisePropertyChanged("SelectedRecirculationChannel");
                base.RaisePropertyChanged("SelectedRecirculationChannelByCombobox");
            }
        }

        public string HeaderInfo
        {
            get { return "Recirculation channel"; }
        }

        public double Density
        {
            get
            {
                if (null != m_Data)
                    return m_Data.Density;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.Density)
                    return;

                m_Data.Density = value;

                base.RaisePropertyChanged("Density");
            }
        }

        public int RecirculationChannelInfoCount
        {
            get
            {
                if (null != Data)
                    return m_Data.NumberOfRecirculationChannel;

                return -1;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.NumberOfRecirculationChannel)
                    return;

                Data.NumberOfRecirculationChannel = value;
                int Value = value;
                bool Changed = false;
                while (Data.RecirculationChannelInfoList.Count > Value)
                {
                    Data.RecirculationChannelInfoList.RemoveAt(Data.RecirculationChannelInfoList.Count - 1);
                    Changed = true;
                }
                while (Data.RecirculationChannelInfoList.Count < Value)
                {
                    Data.RecirculationChannelInfoList.Add(new RecirculationChannelInfo(Data.RecirculationChannelInfoList.Count + 1));
                    Changed = true;
                }

                base.RaisePropertyChanged("RecirculationChannelInfoCount");

                if (Changed)
                {
                    m_prevSelectedRecirculationChannel = SelectedRecirculationChannel;

                    base.RaisePropertyChanged("RecirculationChannelInfos");
                    
                    bool bContains = false;
                    if (null != m_prevSelectedRecirculationChannel)
                    {
                        foreach (RecirculationChannelInfoViewModel vm in m_lstRecirculationChannelInfoViewModel)
                        {
                            if (vm.RecirculationChannelInfoNo.Equals(m_prevSelectedRecirculationChannel.RecirculationChannelInfoNo))
                            {
                                bContains = true;
                                SelectedRecirculationChannel = vm;
                                base.RaisePropertyChanged("SelectedRecirculationChannelByCombobox");
                                break;
                            }
                        }
                    }

                    if (0 < m_lstRecirculationChannelInfoViewModel.Count && !bContains)
                    {
                        SelectedRecirculationChannel = m_lstRecirculationChannelInfoViewModel[m_lstRecirculationChannelInfoViewModel.Count - 1];
                        base.RaisePropertyChanged("SelectedRecirculationChannelByCombobox");
                    }
                }
            }
        }

        public ObservableCollection<RecirculationChannelInfoViewModel> RecirculationChannelInfos
        {
            get
            {
                if (null != Data)
                {
                    m_lstRecirculationChannelInfoViewModel = new List<RecirculationChannelInfoViewModel>();
                    foreach (RecirculationChannelInfo info in Data.RecirculationChannelInfoList)
                        m_lstRecirculationChannelInfoViewModel.Add(new RecirculationChannelInfoViewModel(info));
                    
                    return new ObservableCollection<RecirculationChannelInfoViewModel>(m_lstRecirculationChannelInfoViewModel);
                }

                return null;
            }
        }

        private RecirculationChannelInfoViewModel m_prevSelectedRecirculationChannel;
        public RecirculationChannelInfoViewModel SelectedRecirculationChannel
        {
            get
            {
                if (null != Data && null != RecirculationChannelInfos && 0 <= Data.SelectRecirculationChannel && Data.SelectRecirculationChannel < m_lstRecirculationChannelInfoViewModel.Count)
                    return RecirculationChannelInfos[Data.SelectRecirculationChannel];

                return null;
            }
            set
            {
                if (null == value)
                {
                    Data.SelectRecirculationChannel = -1;
                    base.RaisePropertyChanged("SelectedRecirculationChannel");
                }
                else if (null != Data && null != RecirculationChannelInfos)
                {
                    for (int i = 0; i < RecirculationChannelInfos.Count; ++i)
                    {
                        if (RecirculationChannelInfos[i].RecirculationChannelInfoNo.Equals(value.RecirculationChannelInfoNo))
                        {
                            Data.SelectRecirculationChannel = i;
                            base.RaisePropertyChanged("SelectedRecirculationChannel");
                            break;
                        }
                    }
                }
            }
        }

        public string SelectedRecirculationChannelByCombobox
        {
            get
            {
                if (null != SelectedRecirculationChannel)
                    return SelectedRecirculationChannel.RecirculationChannelInfoNo;
                
                return null;
            }
            set
            {
                if (null != SelectedRecirculationChannel)
                {
                    if (SelectedRecirculationChannel.RecirculationChannelInfoNo != value)
                    {
                        foreach (RecirculationChannelInfoViewModel vm in m_lstRecirculationChannelInfoViewModel)
                        {
                            if (vm.RecirculationChannelInfoNo.Equals(value))
                            {
                                SelectedRecirculationChannel = vm;
                                base.RaisePropertyChanged("SelectedRecirculationChannelByCombobox");
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}