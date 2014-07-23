namespace Metrics.Log4Net.Layout
{
    public class CsvCounterLayout : CsvLayout
    {
        public CsvCounterLayout()
        {
            this.AddCounterColumns();

        }
    }
}