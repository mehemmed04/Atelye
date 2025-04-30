using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.DataAccess.Concretes;
using EmilandAtelye.Domain.ViewModels;
using EmilandAtelye.Domain.Views;
using EmilandAtelye.Logger;
using EmilandAtelye.Services.Abstract;
using EmilandAtelye.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EmilandAtelye
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<IExpenseRepository, ExpenseRepository>();
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                    services.AddSingleton<FileLogger>();
                    services.AddScoped<ICurrencyTypeService, CurrencyTypeService>();
                    services.AddScoped<IOrderService, OrderService>();
                    services.AddScoped<IEncryptionService, EncryptionService>();
                    services.AddScoped<IFileService, FileService>();
                    services.AddScoped<IVersionService, VersionService>();

                    services.AddSingleton<LoginViewModel>();

                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<LoginView>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {

            await _host.StartAsync();

            var versionService = _host.Services.GetRequiredService<IVersionService>();
            var logger = _host.Services.GetRequiredService<FileLogger>();
            try
            {
                if (await versionService.HasUpdate())
                {
                    MessageBox.Show("Yeni Update var");
                    await versionService.UpdateToNewVersion();
                }
                else
                {
                    var loginView = _host.Services.GetRequiredService<LoginView>();
                    loginView.DataContext = _host.Services.GetRequiredService<LoginViewModel>();
                    loginView.Show();
                    logger.Information("App started");
                    base.OnStartup(e);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
           


        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }

}
