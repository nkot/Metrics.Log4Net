namespace Metrics.Log4Net.Layout
{
    public class CsvHistogramLayout : CsvLayout
    {
        public CsvHistogramLayout()
        {
            this.AddHistogramColumns();

        }
    }
}