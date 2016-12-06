using System;
using System.Collections.Generic;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IReportBuilder
    {
        IReportBuilder AddColumn(string title, Func<IDataRow, object> valueFunc);

        IReportBuilder AddRow(IDataRow row);

        IReportBuilder AddData(IEnumerable<IDataRow> data);

        string Build();
    }
}
