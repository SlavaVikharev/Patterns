using System.Collections.Generic;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Models
{
    public class ReportConfig : Config
    {
        public bool WithData { get; set; }

        public bool WithIndex { get; set; }
        public bool WithTotalVolume { get; set; }
        public bool WithTotalWeight { get; set; }

        public bool VolumeSum { get; set; }
        public bool WeightSum { get; set; }
        public bool CostSum { get; set; }
        public bool CountSum { get; set; }

        /*
            Наверное логичнее это было сделать где-то не здесь..
            Можно сделать еще какую-то сущность,
            которая будет знать как про ReportConfig, так и про то,
            в каком формате нам приходят опции программы
        */
        public ReportConfig(ICollection<string> options)
        {
            WithData        = options.Contains("-data");
            WithIndex       = options.Contains("-withIndex");
            WithTotalVolume = options.Contains("-withTotalVolume");
            WithTotalWeight = options.Contains("-withTotalWeight");
            VolumeSum       = options.Contains("-volumeSum");
            WeightSum       = options.Contains("-weightSum");
            CostSum         = options.Contains("-costSum");
            CountSum        = options.Contains("-countSum");
        }
    }
}