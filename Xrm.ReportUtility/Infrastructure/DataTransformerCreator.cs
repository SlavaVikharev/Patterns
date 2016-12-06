using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        /*
            Decorator (каждый из трансформеров)
            "Навешивает" функциональность поверх сервиса
            Сделано для удобства добавления нового DataTransformer
        */
        public static IDataTransformer Create(IConfig config)
        {
            IDataTransformer service = new DataTransformer(config);

            if ((bool) config.GetValue("WithData"))
            {
                service = new WithDataReportTransformer(service);
            }

            if ((bool) config.GetValue("VolumeSum"))
            {
                service = new VolumeSumReportTransformer(service);
            }

            if ((bool) config.GetValue("WeightSum"))
            {
                service = new WeightSumReportTransfomer(service);
            }

            if ((bool) config.GetValue("CostSum"))
            {
                service = new CostSumReportTransformer(service);
            }

            if ((bool) config.GetValue("CountSum"))
            {
                service = new CountSumReportTransformer(service);
            }

            return service;
        }
    }
}