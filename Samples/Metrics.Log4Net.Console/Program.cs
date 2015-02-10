using System;
using System.IO;

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
                        .SetLogDirectory(@".\metrics\")
                        .ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Metrics.Log4Net.config"))                         //or .UseDefaultConfiguration()
                        )
                    .WithLog4NetCsvReport(TimeSpan.FromSeconds(5))
                    .WithLog4NetTextReport(TimeSpan.FromSeconds(5))
                    .WithConsoleReport(TimeSpan.FromSeconds(5))
                );

            SampleMetrics.RunSomeRequests();

            System.Console.WriteLine("done setting things up");
            System.Console.ReadKey();
        }
    }

}
