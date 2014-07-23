namespace Metrics.Log4Net.Layout
{
    public class CsvGaugeLayout : CsvLayout
    {
        public CsvGaugeLayout()
        {
            this.AddGaugeColumns();

        }
    }
}