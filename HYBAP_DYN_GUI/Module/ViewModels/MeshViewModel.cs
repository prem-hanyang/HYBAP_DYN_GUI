using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class MeshViewModel : BindableBase
    {
        private static MeshViewModel g_this;
        public static MeshViewModel This
        {
            get { return g_this; }
        }

        public MeshViewModel()
            : base()
        {
            g_this = this;
            x = 0.0;
            y = 0.0;
            z = -50.0;
            CursorX = 0.0;
            CursorY = 0.0;
            isLClicked = false;
            isRClicked = false;
            ActiveView = null;
        }

        public InputData Data
        {
            get;
            set;
        }

        public string HeaderInfo
        {
            get { return "Mesh"; }
        }

        public string RootDirectory
        {
            get;
            set;
        }

        private bool m_IsBusy;
        public bool IsBusy
        {
            get { return m_IsBusy; }
            set
            {
                m_IsBusy = value;
                base.RaisePropertyChanged("IsBusy");
            }
        }

        public double x
        {
            get;
            set;
        }

        public double y
        {
            get;
            set;
        }

        public double z
        {
            get;
            set;
        }

        public double CursorX
        {
            get;
            set;
        }

        public double CursorY
        {
            get;
            set;
        }

        public bool isLClicked
        {
            get;
            set;
        }

        public bool isRClicked
        {
            get;
            set;
        }

        public System.Windows.IInputElement ActiveView
        {
            get;
            set;
        }
    }
}
