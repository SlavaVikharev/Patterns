using System.Collections.Generic;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IDataGetter
    {
        IEnumerable<IDataRow> GetDataRows(string text);
    }
}
