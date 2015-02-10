using System;
using System.IO;
using System.Linq;
using System.Threading;
using Xunit;
using log4net;

namespace Metrics.Log4Net.Tests
{
    public class MetricsTimerIntegrationTests
    {
         [Fact]
         public void TimerDataIsReportedToFile()
         {
             Metric.Config
               .WithReporting(config => config
                   .WithMetricsLog4NetConfiguration(new MetricsLog4NetConfiguration()
                       .WithRegionalCsvDelimiter()
                       .SetLogDirectory(@".\" + GetType().Name + @"\")
                       .UseDefaultConfiguration()
                       )
                   .WithLog4NetCsvReport(TimeSpan.FromMilliseconds(1))
               );

             using (Metric.Timer("Sample", Unit.None).NewContext())
             {
                 Thread.Sleep(TimeSpan.FromMilliseconds(1));
             }

             Thread.Sleep(TimeSpan.FromSeconds(1));

             Metric.Config.WithReporting(x => x.StopAndClearAllReports());
             LogManager.ShutdownRepository();

             var context = File.ReadAllLines(@".\" + GetType().Name + @"\" + "Metrics.Csv.Timer.csv").ToList();
             foreach (var line in context)
             {
                 Console.WriteLine(line);
             }
             Assert.True(context.Count > 2);
         }
    }
}