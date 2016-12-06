using System.Collections.Generic;
using System.Linq;

namespace Xrm.ReportUtility.Models
{
    public class Arguments
    {
        public string Filename { get; }
        public List<string> Options { get; }

        public Arguments(IReadOnlyList<string> args) {
            Filename = args[0];
            Options = new List<string>(args.Skip(1));
        }
    }
}
