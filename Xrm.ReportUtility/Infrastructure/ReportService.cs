using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public class ReportService : IReportService
    {
        private readonly string _filename;
        
        public ReportService(string filename)
        {
            _filename = filename;
        }

        public Report CreateReport(IDataTransformer dataTransformer)
        {
            var text = File.ReadAllText(_filename);
            var data = GetDataRows(text);
            return dataTransformer.TransformData(data);
        }

        public IDataGetter DataGetter { private get; set; }

        private IDataRow[] GetDataRows(string text) {
            return DataGetter?.GetDataRows(text).ToArray();
        }
    }
}
