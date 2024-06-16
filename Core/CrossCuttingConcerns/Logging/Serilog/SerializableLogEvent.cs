using Serilog.Events;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public class SerializableLogEvent
    {
        private LogEvent _logEvent;

        public SerializableLogEvent(LogEvent logEvent)
        {
            _logEvent = logEvent ?? throw new ArgumentNullException(nameof(logEvent));
        }

        public object Message => _logEvent.RenderMessage();

        public override string ToString()
        {
            return _logEvent.ToString();
        }
    }
}