namespace Metrics.Log4Net.Layout
{
    public class CsvColumn
    {
        public string ColumnName { get; private set; }

        public string LoggingEventPropertyKey { get; private set; }

        public CsvColumn(string columnName, string propertyKey)
        {
            ColumnName = columnName;
            LoggingEventPropertyKey = propertyKey;
        }
    }
}