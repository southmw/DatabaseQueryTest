using Serilog;
using Serilog.Formatting.Display;
using Serilog.Sinks.WinForms.Base;
using Serilog.Sinks.WinForms.Core;

namespace DatabaseQueryTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureSerilog();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain());
        }

        private static void ConfigureSerilog()
        {
            MessageTemplateTextFormatter TextFormat = new ("[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}][{Level}] > {Message} {Exception}{NewLine}");

            Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteToSimpleAndRichTextBox(TextFormat)
                        .CreateLogger();
        }
    }
}