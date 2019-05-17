using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class MeshAndPressurePlotViewModel : BindableBase
    {
        private static MeshAndPressurePlotViewModel g_this;
        public static MeshAndPressurePlotViewModel This
        {
            get { return g_this; }
        }

        public MeshAndPressurePlotViewModel()
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
            ActiveMeshView = null;
            
            x_p = 0.0;
            y_p = 0.0;
            z_p = -50.0;
            CursorX_p = 0.0;
            CursorY_p = 0.0;
            isLClicked_p = false;
            isRClicked_p = false;
            ActivePressureView = null;
        }

        public InputData Data
        {
            get;
            set;
        }

        public string HeaderInfo
        {
            get { return "Plot"; }
        }

        public string RootDirectory
        {
            get;
            set;
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

        public System.Windows.IInputElement ActiveMeshView
        {
            get;
            set;
        }

        public double x_p
        {
            get;
            set;
        }

        public double y_p
        {
            get;
            set;
        }

        public double z_p
        {
            get;
            set;
        }

        public double CursorX_p
        {
            get;
            set;
        }

        public double CursorY_p
        {
            get;
            set;
        }

        public bool isLClicked_p
        {
            get;
            set;
        }

        public bool isRClicked_p
        {
            get;
            set;
        }

        public System.Windows.IInputElement ActivePressureView
        {
            get;
            set;
        }
    }
}
