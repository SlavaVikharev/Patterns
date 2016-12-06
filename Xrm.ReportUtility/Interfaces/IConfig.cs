using System.Collections.Generic;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IConfig
    {
        HashSet<string> Props { get; }

        object GetValue(string prop);
    }
}
