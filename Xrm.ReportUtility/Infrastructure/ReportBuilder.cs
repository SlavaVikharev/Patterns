using System;
using System.Collections.Generic;
using System.Text;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure
{
    public class ReportBuilder : IReportBuilder
    {
        public static string Delimeter = "\t";

        private readonly List<Tuple<string, Func<IDataRow, object>>> _columns;
        private readonly List<IDataRow> _rows;
        
        public ReportBuilder() {
            _rows = new List<IDataRow>();
            _columns = new List<Tuple<string, Func<IDataRow, object>>>();
        }

        public IReportBuilder AddColumn(string title, Func<IDataRow, object> valueFunc)
        {
            _columns.Add(Tuple.Create(title, valueFunc));
            return this;
        }

        public IReportBuilder AddRow(IDataRow row) {
            _rows.Add(row);
            return this;
        }

        public IReportBuilder AddData(IEnumerable<IDataRow> data) {
            foreach (var row in data)
            {
                AddRow(row);
            }
            return this;
        }

        private string BuildHeader()
        {
            var header = new StringBuilder();
            foreach (var column in _columns)
            {
                header.Append(column.Item1 + Delimeter);
            }
            return header.ToString();
        }

        public string Build() {
            var result = new StringBuilder();

            result.AppendLine(BuildHeader());

            foreach (var row in _rows)
            {
                var rowString = new StringBuilder();
                foreach (var column in _columns)
                {
                    rowString.Append(column.Item2(row) + Delimeter);
                }
                result.AppendLine(rowString.ToString());
            }

            return result.ToString();
        }
    }
}