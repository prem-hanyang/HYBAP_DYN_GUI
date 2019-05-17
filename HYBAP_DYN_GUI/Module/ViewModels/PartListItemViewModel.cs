using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class PartListItemViewModel : BindableBase
    {
        private Part m_Data;

        public PartListItemViewModel(Part data)
            : base()
        {
            m_Data = data;
        }

        public string PartNo
        {
            get
            {
                if (null != m_Data)
                    return string.Format("Part{0:D2}", m_Data.PartNo);

                return string.Empty;
            }
        }

        public PartPropertyViewModel PartPropertyViewModel
        {
            get
            {
                PartPropertyViewModel vm = null;
                if (null != m_Data)
                {
                    switch (m_Data.BearingType)
                    {
                        case 1:
                            vm = new PartPlainJournalViewModel(m_Data.Property as PartPropertyPlainJournal);
                            break;
                        case 2:
                            vm = new PartGroovedJournalViewModel(m_Data.Property as PartPropertyGroovedJournal);
                            break;
                        case 3:
                            vm = new PartPlainThrustClosedEndViewModel(m_Data.Property as PartPropertyPlainThrustClosedEnd);
                            break;
                        case 4:
                            vm = new PartGroovedThrustDonutViewModel(m_Data.Property as PartPropertyGroovedThrustDonut);
                            break;
                        case 5:
                            vm = new PartPlainThrustDonutViewModel(m_Data.Property as PartPropertyPlainThrustDonut);
                            break;
                    }
                }

                return vm;
            }
        }

        public PartResultViewModel PartResultViewModel
        {
            get
            {
                PartResultViewModel vm = null;
                if (null != m_Data)
                {
                    vm = new PartResultViewModel(m_Data.ResultData);
                }
                return vm;
            }
        }
    }
}
