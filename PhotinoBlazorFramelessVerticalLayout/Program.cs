using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using PhotinoBlazorFramelessVerticalLayout.Services;
using System;
using System.Net.Http;

namespace PhotinoBlazorFramelessVerticalLayout
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

            appBuilder.Services
                // Specify where to find localization files. The path is relative to project root
                .AddLocalization(options => options.ResourcesPath = "Localization")
                .AddBootstrapBlazor(null,
                localizationOptions =>
                {
                    //Specify localization file format Program.{xx}.resx where xx is culture such as en, zh.
                    localizationOptions.ResourceManagerStringLocalizerType = typeof(Program);
                })
                .AddSingleton<PhotinoService>()
                .AddLogging();

            // register root component and selector
            appBuilder.RootComponents.Add<App>("app");

            var app = appBuilder.Build();
            app.MainWindow.BrowserControlInitParameters = "--enable-features=\"msWebView2EnableDraggableRegions\"";
            // customize window
            app.MainWindow
                .SetChromeless(true)
                .SetResizable(false) // TODO: it has no effect after SetChromeless(true)
                .SetTitle("Photino Blazor Sample")
                .SetSize(new System.Drawing.Size(1024, 768))
                .SetMinSize(600, 400)
                // Center window in the middle of the screen
                .Center();

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
            };

            var photinoService = app.Services.GetService<PhotinoService>();
            photinoService!.App = app;
            app.Run();
        }
    }
}
