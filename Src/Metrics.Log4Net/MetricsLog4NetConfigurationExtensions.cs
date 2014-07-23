using System;
using System.Globalization;
using Metrics.Log4Net;
using Metrics.Log4Net.Layout;

namespace Metrics
{
    public static class MetricsLog4NetConfigurationExtensions
    {
        /// <summary>
        /// Configures Metrics.Log4Net to use CSV delimiter defined in <see cref="TextInfo.ListSeparator"/>
        /// </summary>
        public static MetricsLog4NetConfiguration WithRegionalCsvDelimiter(this MetricsLog4NetConfiguration configuration)
        {
            CsvDelimiter.SetDelimiter(CultureInfo.CurrentCulture.TextInfo.ListSeparator);

            return configuration;
        }

        /// <summary>
        /// Configures Metrics.Log4Net to use custom CSV delimiter
        /// </summary>
        public static MetricsLog4NetConfiguration WithCustomCsvDelimiter(this MetricsLog4NetConfiguration configuration, string csvDelimiter)
        {
            if (csvDelimiter == null) throw new ArgumentNullException("csvDelimiter");
            CsvDelimiter.SetDelimiter(csvDelimiter);

            return configuration;
        }

        /// <summary>
        /// Metrics.Log4Net loads configuration and watches for changes in Metrics.Log4Net.config file
        /// </summary>
        /// <remarks>Note that <see cref="WithCustomCsvDelimiter"/> should be called before calling this method as Log4Net immediately will create header with default CSV delimiter.</remarks>
        public static MetricsLog4NetConfiguration WithDefaultConfigFile(this MetricsLog4NetConfiguration configuration, string logDirectory = @".\Logs\")
        {
            DefaultLog4NetConfiguration.ConfigureAndWatch(logDirectory);

            return configuration;
        }

    }
}