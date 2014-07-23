namespace Metrics.Log4Net.Layout
{
    public class CsvMeterLayout : CsvLayout
    {
        public CsvMeterLayout()
        {
            this.AddMeterColumns();

        }
    }
}