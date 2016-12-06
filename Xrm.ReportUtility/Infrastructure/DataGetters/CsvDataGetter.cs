using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.DataGetters
{
    public class CsvDataGetter : IDataGetter
    {
        public IEnumerable<IDataRow> GetDataRows(string text) {
            using (TextReader textReader = new StringReader(text))
            {
                var csvReader = new CsvReader(textReader);

                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.RegisterClassMap<RowDataMapper>();

                return csvReader.GetRecords<DataRow>();
            }
        }
    }
}