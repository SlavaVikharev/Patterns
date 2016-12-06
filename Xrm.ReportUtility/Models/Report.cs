using System.Collections.Generic;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Models
{
    public class Report
    {
        public IConfig Config { get; set; }
        public IEnumerable<IDataRow> Data { get; set; }
        public IList<ReportRow> Rows { get; set; }
    }
}
