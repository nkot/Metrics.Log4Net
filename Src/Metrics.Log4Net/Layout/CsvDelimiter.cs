using System;

namespace Metrics.Log4Net.Layout
{
    public static class CsvDelimiter
    {
        private static string delimiter = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        public static string Delimiter
        {
            get { return delimiter; }
        }

        public static void SetDelimiter(string newDelimiter)
        {
            if (newDelimiter == null) throw new ArgumentNullException("newDelimiter");
            delimiter = newDelimiter;
        }
    }
}