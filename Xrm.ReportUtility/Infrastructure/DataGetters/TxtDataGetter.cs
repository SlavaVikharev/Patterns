using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.DataGetters
{
    public class TxtDataGetter : IDataGetter
    {
        public IEnumerable<IDataRow> GetDataRows(string text)
        {
            var lines = text.Split(new[] { "\r\n" }, StringSplitOptions.None).Skip(1);

            foreach (var line in lines)
            {
                var items = Regex.Split(line, @"\s+");

                yield return new DataRow {
                    Name = items[0],
                    Volume = decimal.Parse(items[1]),
                    Weight = decimal.Parse(items[2]),
                    Cost = decimal.Parse(items[3]),
                    Count = decimal.Parse(items[4])
                };
            }
        }
    }
}