using System;
using System.Runtime.InteropServices;

namespace TestReportsApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(RuntimeInformation.OSDescription);

            var report = new Reports.HiddenColumnsReport();

            // https://docs.devexpress.com/XtraReports/401730/create-end-user-reporting-applications/web-reporting/asp-net-core-reporting/use-the-devexpress-cross-platform-drawing-engine
            if(!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                DevExpress.Printing.CrossPlatform.CustomEngineHelper.RegisterCustomDrawingEngine(
                    typeof(
                        DevExpress.CrossPlatform.Printing.DrawingEngine.PangoCrossPlatformEngine
                ));
            }

            report.CreateDocument();
            report.ExportToPdf("HiddenColumnsReport.pdf");
            report.ExportToImage("HiddenColumnsReport.png", new DevExpress.XtraPrinting.ImageExportOptions() { Resolution = 96 });

            Console.WriteLine("Done!");
        }
    }
}
