using HandyControl.Tools;
using System;
using System.IO;
using System.Net;
using System.Runtime;
using System.Windows;
using KissU.CPlatform;
using KissU.ServiceProxy;
using KissU.Workbench.Data;
using KissU.Workbench.Tools.Helper;
using KissU.Workbench.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Volo.Abp;

namespace KissU.Workbench
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private readonly IAbpApplicationWithExternalServiceProvider _application;

        public App()
        {
            var cachePath = $"{AppDomain.CurrentDomain.BaseDirectory}Cache";
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            ProfileOptimization.SetProfileRoot(cachePath);
            ProfileOptimization.StartProfile("Profile");

            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .CreateLogger();

            _host = CreateHostBuilder().Build();
            _application = _host.Services.GetService<IAbpApplicationWithExternalServiceProvider>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
                try
                {
                    Log.Information("Starting WPF host.");
                    await _host.StartAsync();
                    _application.Initialize(_host.Services);
                    ViewModelLocator.Instance.Init(_host.Services);
                    var window = _host.Services.GetService<MainWindow>();
                    _host.Services.GetService<MainWindow>()?.Show();
                    WindowsHelper.RepairWindowBehavior(window);
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Host terminated unexpectedly!");
                }

                base.OnStartup(e);
                ShutdownMode = ShutdownMode.OnMainWindowClose;
                GlobalData.Init();
                ConfigHelper.Instance.SetWindowDefaultStyle();
                ConfigHelper.Instance.SetNavigationWindowDefaultStyle();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            _application.Shutdown();
            await _host.StopAsync();
            _host.Dispose();
            Log.CloseAndFlush();
            base.OnExit(e);
            GlobalData.Save();
        }

        private IHostBuilder CreateHostBuilder()
        {
            return Host
                .CreateDefaultBuilder()
                .AddMicroService(builder =>
                {
                    builder.AddServiceRuntime()
                        .AddRelateService()
                        .AddConfigurationWatch()
                        .AddServiceEngine();
                })
                .UseClient()
                .UseAutofac();
        }
    }
}
