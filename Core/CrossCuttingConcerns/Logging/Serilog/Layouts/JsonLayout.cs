using Serilog.Events;
using Serilog.Formatting.Json;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Layouts
{
    public class JsonLayout
    {
        private readonly JsonFormatter _formatter;

        public JsonLayout()
        {
            _formatter = new JsonFormatter(renderMessage: true);
        }

        public void Format(TextWriter writer, LogEvent logEvent)
        {
            _formatter.Format(logEvent, writer);
        }
    }
}