using System;
using System.Runtime.InteropServices;

namespace TestReportsApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(RuntimeInformation.OSDescription);

            var report = new Reports.HiddenColumnsReport();

            object engine = new DevExpress.CrossPlatform.Printing.DrawingEngine.PangoCrossPlatformEngine();
            DevExpress.XtraReports.Native.CrossPlatform
               .CrossPlatformCustomEngineHelper.RegisterCustomEngine(report, engine);

            report.CreateDocument();
            report.ExportToPdf("HiddenColumnsReport.pdf");
            report.ExportToImage("HiddenColumnsReport.png", new DevExpress.XtraPrinting.ImageExportOptions() { Resolution = 96 });

            Console.WriteLine("Done!");
        }
    }
}
