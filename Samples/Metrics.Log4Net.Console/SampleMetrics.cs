using System;
using System.Collections.Generic;
using System.Threading;
using Metrics.Utils;

namespace Metrics.Log4Net.Console
{
    public class SampleMetrics
    {

        private readonly Counter totalRequestsCounter = Metric.Counter<SampleMetrics>("Requests", Unit.Requests);

        private readonly Counter concurrentRequestsCounter = Metric.Counter("SampleMetrics.ConcurrentRequests", Unit.Requests);

        private readonly Histogram histogramOfData = Metric.Histogram<SampleMetrics>("ResultsExample", Unit.Items, SamplingType.LongTerm);

        private readonly Meter meter = Metric.Meter<SampleMetrics>("Requests", Unit.Requests);

        private readonly Timer timer = Metric.Timer<SampleMetrics>("Requests", Unit.Requests, SamplingType.FavourRecent, TimeUnit.Seconds, TimeUnit.Milliseconds);

        private double someValue = 1;

        public SampleMetrics()
        {
            Metric.Gauge("SampleMetrics.DataValue", () => this.someValue, new Unit("$"));
        }

        public void Request(int i)
        {
            using (this.timer.NewContext()) 
            {
                someValue *= (i + 1); 

                this.concurrentRequestsCounter.Increment(); 

                this.totalRequestsCounter.Increment(); 

                this.meter.Mark();

                this.histogramOfData.Update(ThreadLocalRandom.NextLong() % 5000); 

                int ms = Math.Abs((int)(ThreadLocalRandom.NextLong() % 3000L));
                Thread.Sleep(ms);

                this.concurrentRequestsCounter.Decrement(); 
            }
        }


        public static void RunSomeRequests()
        {
            var test = new SampleMetrics();
            var tasks = new List<Thread>();
            for (var i = 0; i < 10; i++)
            {
                var j = i;
                tasks.Add(new Thread(() => test.Request(j)));
            }

            tasks.ForEach(t => t.Start());
            tasks.ForEach(t => t.Join());
        }
    }
}
