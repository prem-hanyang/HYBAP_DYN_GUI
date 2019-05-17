using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class PartViewModel : BindableBase
    {
        private static PartViewModel g_this;
        public static PartViewModel This
        {
            get { return g_this; }
        }

        private MainData m_Data;
        private List<PartListItemViewModel> m_lstPartPropertyViewModel;

        public PartViewModel()
            : base()
        {
            g_this = this;
        }

        public MainData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("Parts");
            }
        }

        public string HeaderInfo
        {
            get { return "Part"; }
        }

        public ObservableCollection<PartListItemViewModel> Parts
        {
            get
            {
                if (null != Data)
                {
                    m_lstPartPropertyViewModel = new List<PartListItemViewModel>();
                    foreach (Part part in Data.PartList)
                        m_lstPartPropertyViewModel.Add(new PartListItemViewModel(part));
                    return new ObservableCollection<PartListItemViewModel>(m_lstPartPropertyViewModel);
                }

                return null;
            }
        }

        public void RaisePartChanged()
        {
            base.RaisePropertyChanged("Parts");
        }
    }
}
