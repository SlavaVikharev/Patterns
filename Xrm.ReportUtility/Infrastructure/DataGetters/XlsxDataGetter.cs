using System.Collections.Generic;
using System.Linq;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure.DataGetters
{
    public class XlsxDataGetter : IDataGetter
    {
        public IEnumerable<IDataRow> GetDataRows(string text)
        {
            return Enumerable.Empty<IDataRow>();
        }
    }
}