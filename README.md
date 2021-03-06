Metrics.Log4Net Adapter
===============
Log4Net adapter for [Metrics.Net](https://github.com/etishor/Metrics.NET) library.

[![Build status](https://ci.appveyor.com/api/projects/status/v9ndc1i857uumhp6)](https://ci.appveyor.com/project/nkot/metrics-log4net)

### Intro

This is an adapter for Iulian Margarintescu's [Metrics.Net](https://github.com/etishor/Metrics.NET) library. 

**Main Features**
*    Rolling CSV File Support
*    Text File Reporting
*    Custom Log4Net Adapters can be plugged in

Supported runtimes: .Net 4.5

### Quick Usage Sample
```csharp
            Metric.Config
                .WithReporting(config => config
                    .WithMetricsLog4NetConfiguration(new MetricsLog4NetConfiguration()
                        .WithRegionalCsvDelimiter()
                        .SetLogDirectory(@".\metrics\")
                        .UseDefaultConfiguration()
                        )
                    .WithLog4NetCsvReports(TimeSpan.FromSeconds(5))
                );
```

### Download
NuGet package - [Metrics.Log4Net](https://www.nuget.org/packages/Metrics.Log4Net/)

### Documentation
Look at [wiki](https://github.com/nkot/Metrics.Log4Net/wiki) pages

### TODO

> -    [done] Deploy to NuGet
> -    Write tests for text file reporter
> -    Write more documentation

-------------

> Written with [StackEdit](https://stackedit.io/).
