using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Models
{
    public class DataRow : IDataRow
    {
        public string Name { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
        public decimal Cost { get; set; }
        public decimal Count { get; set; }

        public object GetValue(string prop)
        {
            return GetType().GetProperty(prop).GetValue(this);
        }
    }
}