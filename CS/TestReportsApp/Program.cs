using System;
using System.Runtime.InteropServices;

namespace TestReportsApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(RuntimeInformation.OSDescription);

            // https://docs.devexpress.com/XtraReports/401730/create-end-user-reporting-applications/web-reporting/asp-net-core-reporting/use-the-devexpress-cross-platform-drawing-engine

            // Register the Cross-Platform drawing engine before you create a report instance.
            RegisterDrawingEngine();

            var report = new Reports.HiddenColumnsReport();

            report.CreateDocument();
            report.ExportToPdf("HiddenColumnsReport.pdf");
            report.ExportToImage("HiddenColumnsReport.png", new DevExpress.XtraPrinting.ImageExportOptions() { Resolution = 200 });

            Console.WriteLine("Done!");
        }
        static void RegisterDrawingEngine() {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                DevExpress.Printing.CrossPlatform.CustomEngineHelper.RegisterCustomDrawingEngine(
                    typeof(
                        DevExpress.CrossPlatform.Printing.DrawingEngine.PangoCrossPlatformEngine
                ));
            }
        }
    }
}
