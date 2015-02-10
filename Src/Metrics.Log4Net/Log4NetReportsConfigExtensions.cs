using System;
using Metrics.Log4Net;
using Metrics.Log4Net.Appenders;
using Metrics.Reporters;
using Metrics.Reports;

namespace Metrics
{
    public static class Log4NetReportsConfigExtensions
    {
        /// <summary>
        /// Configures Metrics.Log4Net with settings defined in <see cref="MetricsLog4NetConfiguration"/>
        /// </summary>
        public static MetricsReports WithMetricsLog4NetConfiguration(this MetricsReports reports, MetricsLog4NetConfiguration log4NetConfig)
        {
            if (log4NetConfig == null) throw new ArgumentNullException("log4NetConfig");

            return reports;
        }

        /// <summary>
        /// Write CSV Metrics Report using Log4Net. 
        /// </summary>
        /// <param name="reports">Instance to configure</param>
        /// <param name="interval">Interval at which to report values</param>
        /// <returns>Same Reports instance for chaining</returns>
        public static MetricsReports WithLog4NetCsvReport(this MetricsReports reports, TimeSpan interval)
        {
            if (reports == null) throw new ArgumentNullException("reports");
          
            reports.WithReport(new CSVReport(new Log4NetCsvAppender(new RealLog4NetLoggerProvider(), new LoggingEventMapper())), interval);

            return reports;
        }


        /// <summary>
        /// Write human readable text using Log4Net
        /// </summary>
        /// <param name="reports">Instance to configure</param>
        /// <param name="interval">Interval at which to report values</param>
        /// <returns>Same Reports instance for chaining</returns>
        public static MetricsReports WithLog4NetTextReport(this MetricsReports reports, TimeSpan interval)
        {
            if (reports == null) throw new ArgumentNullException("reports");

            reports.WithReport(new Log4NetTextReporter(), interval);
            return reports;
        }
    }
}
