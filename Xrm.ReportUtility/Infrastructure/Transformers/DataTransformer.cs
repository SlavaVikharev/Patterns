using System.Collections.Generic;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    class DataTransformer : IDataTransformer
    {
        private readonly IConfig _config;

        public DataTransformer(IConfig config)
        {
            _config = config;    
        }

        public Report TransformData(IDataRow[] data)
        {
            return new Report
            {
                Config = _config,
                Data = new DataRow[0],
                Rows = new List<ReportRow>()
            };
        }
    }
}
