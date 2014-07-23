using System;

namespace Metrics.Log4Net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Metric.Config
                .WithErrorHandler(x => System.Console.WriteLine(x.ToString()))
                //.WithAllCounters()
                .WithReporting(config => config
                    .WithMetricsLog4NetConfiguration(new MetricsLog4NetConfiguration()
                        .WithRegionalCsvDelimiter()
                        .WithDefaultConfigFile())
                    .WithLog4NetCsvReports(TimeSpan.FromSeconds(5))
                    .WithLog4NetTextReports(TimeSpan.FromSeconds(5))
                    .WithConsoleReport(TimeSpan.FromSeconds(5))
                );

            SampleMetrics.RunSomeRequests();

            System.Console.WriteLine("done setting things up");
            System.Console.ReadKey();
        }
    }

}
