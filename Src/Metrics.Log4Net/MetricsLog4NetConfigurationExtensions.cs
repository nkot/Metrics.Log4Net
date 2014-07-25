using System;
using System.Globalization;
using System.IO;
using System.Reflection;
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
        public static MetricsLog4NetConfiguration ConfigureAndWatch(this MetricsLog4NetConfiguration configuration, FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException(fileInfo.FullName);
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(fileInfo);

            return configuration;
        }

        public static MetricsLog4NetConfiguration SetLogDirectory(this MetricsLog4NetConfiguration configuration, string directory)
        {
            log4net.GlobalContext.Properties["Metrics.Log4Net.LogDirectory"] = directory;

            return configuration;
        }

        public static MetricsLog4NetConfiguration UseDefaultConfiguration(this MetricsLog4NetConfiguration configuration)
        {
            if (String.IsNullOrEmpty(log4net.GlobalContext.Properties["Metrics.Log4Net.LogDirectory"] as string))
            {
                throw new InvalidOperationException("Make sure you have executed SetLogDirectory before calling this method.");
            }

            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "Metrics.Log4Net.Metrics.Log4Net.config";

            log4net.Config.XmlConfigurator.Configure(assembly.GetManifestResourceStream(resourceName));

            return configuration;
        }
    }
}