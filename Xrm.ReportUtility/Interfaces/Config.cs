using System.Collections.Generic;
using System.Linq;

namespace Xrm.ReportUtility.Interfaces
{
    public abstract class Config : IConfig
    {
        public HashSet<string> Props { get; }

        public object GetValue(string prop)
        {
            return GetType().GetProperty(prop).GetValue(this);
        }

        protected Config() {
            Props = new HashSet<string>(GetType().GetProperties().Select(p => p.Name));
        }
    }
}
