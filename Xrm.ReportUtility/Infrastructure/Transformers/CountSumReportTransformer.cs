using System.Collections.Generic;
using System.Linq;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class CountSumReportTransformer : ReportServiceTransformerBase
    {
        public CountSumReportTransformer(IDataTransformer reportService) : base(reportService) { }

        public override Report TransformData(IDataRow[] data) {
            var report = DataTransformer.TransformData(data);

            report.Rows.Add(new ReportRow
            {
                Name = "Суммарное количество",
                Value = data.Sum(i => (decimal) i.GetValue("Count"))
            });

            return report;
        }
    }
}
