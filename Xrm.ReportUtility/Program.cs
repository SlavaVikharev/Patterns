using System;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        public static void Main(string[] args) {
            var arguments       = new Arguments(args);
            var reportConfig    = new ReportConfig(arguments.Options);
            var dataTransformer = DataTransformerCreator.Create(reportConfig);
            var service         = ReportServiceGetter.Get(arguments.Filename);
            var report          = service.CreateReport(dataTransformer);
            var reportBuilder   = new ReportBuilder();

            PrintReport(report, reportBuilder);
        }

        private static void PrintReport(Report report, IReportBuilder reportBuilder)
        {
            if ((bool) report.Config.GetValue("WithIndex"))
            {
                reportBuilder.AddColumn("№", r => "_");
            }

            reportBuilder
                .AddColumn("Наименование",   r => r.GetValue("Name"))
                .AddColumn("Объём упаковки", r => r.GetValue("Volume"))
                .AddColumn("Масса упаковки", r => r.GetValue("Weight"))
                .AddColumn("Стоимость",      r => r.GetValue("Cost"))
                .AddColumn("Количество",     r => r.GetValue("Count"));

            if ((bool) report.Config.GetValue("WithTotalVolume"))
            {
                reportBuilder.AddColumn("Суммарный объём",
                    r => (decimal) r.GetValue("Value") * (decimal) r.GetValue("Count"));
            }

            if ((bool) report.Config.GetValue("WithTotalWeight"))
            {
                reportBuilder.AddColumn("Суммарный вес",
                    r => (decimal) r.GetValue("Weight") * (decimal) r.GetValue("Count"));
            }

            reportBuilder.AddData(report.Data);

            Console.WriteLine(reportBuilder.Build());
            Console.WriteLine();
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}