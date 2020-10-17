using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Shouldly;

namespace ZMSoftware.Core.Testing.Logging
{
    public class FakeLogger<TLoggerCategory> : ILogger<TLoggerCategory>
    {
        private readonly ICollection<LogEntry> _logs = new List<LogEntry>();

        public IEnumerable<LogEntry> LogEntries => _logs;

        public IDisposable BeginScope<TState>(TState state) => TestLoggingScope.Instance;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));

            var message = formatter(state, exception);

            _logs.Add(new LogEntry(logLevel, eventId, state, exception, message));
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void ReceivedInformation(int count, string message) => ReceivedLog(count, message, LogLevel.Information, null, null);

        public void ReceivedWarning<TExc>(int count, string message, TExc exception) where TExc : Exception => ReceivedLog(count, message, LogLevel.Warning, exception, exception?.GetType());

        public void ReceivedWarning(int count, string message) => ReceivedLog(count, message, LogLevel.Warning, null, null);

        public void ReceivedError<TExc>(int count, string message, TExc exception) where TExc : Exception => ReceivedLog(count, message, LogLevel.Error, exception, typeof(TExc));

        public void ReceivedError(int count, string message) => ReceivedLog(count, message, LogLevel.Error, null, null);

        private void ReceivedLog(int count, string message, LogLevel logLevel, Exception exception, Type exceptionType) =>
            _logs
                .Where(x => x.Message?.Contains(message) ?? false)
                .Where(x => exception == null || x.Exception?.Message == exception.Message)
                .Where(x => exceptionType == null || x.Exception?.GetType() == exceptionType)
                .Count(x => x.LogLevel == logLevel)
                .ShouldBe(count);
    }
}
