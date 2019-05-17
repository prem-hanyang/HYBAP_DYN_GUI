using Microsoft.Practices.Unity;
using Module.Views;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;

namespace Module
{
    public class Module : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public Module(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<Main>();
            _container.RegisterTypeForNavigation<Part>();
//            _container.RegisterTypeForNavigation<RecirculationChannel>();
            _container.RegisterTypeForNavigation<Mesh>();
            _container.RegisterTypeForNavigation<DYN>();
            _container.RegisterTypeForNavigation<DYNAnalysis>();
            //_container.RegisterTypeForNavigation<StaticAndDynamicAnalysis>();
//            _container.RegisterTypeForNavigation<MeshAndPressurePlot>();
            _container.RegisterTypeForNavigation<StaticAndDynamicAnalysisResult>();
//            _container.RegisterTypeForNavigation<DAFUL>();

            _regionManager.RequestNavigate("ContentRegion", "Main");
            _regionManager.RequestNavigate("ContentRegion", "Part");
            //_regionManager.RequestNavigate("ContentRegion", "RecirculationChannel");
            _regionManager.RequestNavigate("ContentRegion", "Mesh");
            _regionManager.RequestNavigate("ContentRegion", "DYN");
            _regionManager.RequestNavigate("ContentRegion", "DYNAnalysis");
            //_regionManager.RequestNavigate("ContentRegion", "StaticAndDynamicAnalysis");
            //_regionManager.RequestNavigate("ContentRegion", "MeshAndPressurePlot");
            _regionManager.RequestNavigate("ContentRegion", "StaticAndDynamicAnalysisResult");
            //_regionManager.RequestNavigate("ContentRegion", "DAFUL");
        }
    }
}
