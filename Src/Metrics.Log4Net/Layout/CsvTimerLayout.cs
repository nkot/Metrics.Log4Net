namespace Metrics.Log4Net.Layout
{
    public class CsvTimerLayout : CsvLayout
    {
        public CsvTimerLayout()
        {
            this.AddTimerColumns();
        }
    }
}
