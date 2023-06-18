using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June12CSV.Data
{
   public class CSV
    {
        public static string BuildPeopleCsv(List<Person> people)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);
            using var csv = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csv.WriteRecords(people);
            return builder.ToString();
        }
        public static List<Person> ReadFromCsv(string csv)
        {
            var stringReader = new StringReader(csv);
            using var reader = new CsvReader(stringReader, CultureInfo.InvariantCulture);
            return reader.GetRecords<Person>().ToList();
        }
        public static List<Person> GetCsvFromBytes(byte[] csvBytes)
        {
            using var memoryStream = new MemoryStream(csvBytes);
            var streamReader = new StreamReader(memoryStream);
            using var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            return reader.GetRecords<Person>().ToList();
        }
    }
}
