namespace Xrm.ReportUtility.Interfaces
{
    public abstract class Config : IConfig
    {
        public object GetValue(string prop)
        {
            return GetType().GetProperty(prop).GetValue(this);
        }
    }
}
