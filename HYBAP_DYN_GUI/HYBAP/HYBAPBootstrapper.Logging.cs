using Prism.Logging;

namespace HYBAP
{
    public partial class HYBAPBootstrapper
    {
        private readonly EnterpriseLibraryLoggerAdapter m_logger = new EnterpriseLibraryLoggerAdapter();

        protected override ILoggerFacade CreateLogger()
        {
            return this.m_logger;
        }
    }
}
