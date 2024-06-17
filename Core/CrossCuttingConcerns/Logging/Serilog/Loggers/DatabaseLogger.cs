using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger(ILogger logger) : base(logger: null!)
        {
        }
    }
}