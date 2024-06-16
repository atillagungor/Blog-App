using Serilog;
using Serilog.Core;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public abstract class LoggerServiceBase : IDisposable
    {
        private readonly Logger _logger;

        protected LoggerServiceBase()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"C:\Logs\log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Info(object logMessage)
        {
            _logger.Information(logMessage.ToString());
        }

        public void Debug(object logMessage)
        {
            _logger.Debug(logMessage.ToString());
        }

        public void Warn(object logMessage)
        {
            _logger.Warning(logMessage.ToString());
        }

        public void Fatal(object logMessage)
        {
            _logger.Fatal(logMessage.ToString());
        }

        public void Error(object logMessage)
        {
            _logger.Error(logMessage.ToString());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _logger.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}