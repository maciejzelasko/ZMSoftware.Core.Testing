using System;
using Microsoft.Extensions.Logging;

namespace ZMSoftware.Core.Testing.Logging
{
    public class LogEntry
    {
        public LogEntry(LogLevel logLevel, EventId eventId, object state, Exception exception, string message)
        {
            LogLevel = logLevel;
            EventId = eventId;
            State = state;
            Exception = exception;
            Message = message;
        }

        public LogLevel LogLevel { get; }

        public EventId EventId { get; }

        public object State { get; }

        public Exception Exception { get; }

        public string Message { get; }
    }
}
