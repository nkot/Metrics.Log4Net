using System;
using System.Collections.Generic;
using Metrics.Log4Net.Layout;
using Metrics.Reporters;
using log4net.Core;

namespace Metrics.Log4Net.Appenders
{
    public class Log4NetCsvAppender: Metrics.Reporters.CSVFileAppender
    {
        private readonly ILoggerProvider loggerProvider;
        private readonly ILoggingEventMapper loggingEventMapper;

        public Log4NetCsvAppender(ILoggerProvider loggerProvider, ILoggingEventMapper loggingEventMapper):base("metrics", CsvDelimiter.Delimiter)
        {
            this.loggerProvider = loggerProvider;
            this.loggingEventMapper = loggingEventMapper;
        }

        public override void AppendLine(DateTime timestamp, string metricType, string metricName, IEnumerable<CSVReporter.Value> values)
        {
            var metricsData = new MetricsData { MetricType = metricType, MetricName = metricName, Values = values };

            var logger = loggerProvider.GetLogger(metricsData);

            if (!logger.IsEnabledFor(Level.Info)) return;

            var loggingEvent = loggingEventMapper.MapToLoggingEvent(logger.Name, timestamp, metricsData);

            logger.Log(loggingEvent);
        }
    }
}
