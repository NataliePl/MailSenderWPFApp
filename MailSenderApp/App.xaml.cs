using MailSenderApp.Infrastructure;
using MailSender.lib.Interfaces;
using MailSender.lib;
using MailSenderApp.Infrastructure.Services;
using MailSenderApp.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MailSender.lib.Service;
using MailSenderApp.Infrastructure.InMemory;
using MailSenderApp.Models;

namespace MailSenderApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _Hosting;
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        public static IHost Hosting => _Hosting
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<ServerEditDialogViewModel, ServerEditDialog>();
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => (HostBuilder)Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", false, true))
            .ConfigureServices(ConfigureServices)
            ;

        private static void ConfigureServices (HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<StatisticViewModel>();


            services.AddSingleton<IRepository<Server>, ServersRepository>();
            services.AddSingleton<IRepository<Sender>, SendersRepository>();
            services.AddSingleton<IRepository<Message>, MessagesRepository>();
            services.AddSingleton<IRepository<Recipient>, RecipientsRepository>();
            
            
            services.AddSingleton<IStatistic, InMemoryStatisticService>();
#if DEBUG
            services.AddSingleton<IMailService, DebugMailService>();
#else
            services.AddSingleton<IMailService, SmtpMailService>();
#endif
        }
    }
}
