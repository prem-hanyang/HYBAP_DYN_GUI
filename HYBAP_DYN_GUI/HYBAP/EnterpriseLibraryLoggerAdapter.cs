using Microsoft.Practices.EnterpriseLibrary.Logging;
using Prism.Logging;

namespace HYBAP
{
    public class EnterpriseLibraryLoggerAdapter : ILoggerFacade
    {
        public EnterpriseLibraryLoggerAdapter()
        {
            Logger.SetLogWriter(new LogWriter(new LoggingConfiguration()));
        }

        public void Log(string message, Category category, Priority priority)
        {
            Logger.Write(message, category.ToString(), (int)priority);
        }
    }
}
