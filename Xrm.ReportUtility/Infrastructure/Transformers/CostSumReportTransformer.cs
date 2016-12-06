using System.Linq;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class CostSumReportTransformer : ReportServiceTransformerBase
    {
        public CostSumReportTransformer(IDataTransformer dataTransformer) : base(dataTransformer) { }

        public override Report TransformData(IDataRow[] data)
        {
            var report = DataTransformer.TransformData(data);
            
            report.Rows.Add(new ReportRow
            {
                Name = "Суммарная стоимость",
                Value = data.Sum(i => (decimal) i.GetValue("Cost") * (decimal) i.GetValue("Count"))
            });

            return report;
        }
    }
}
