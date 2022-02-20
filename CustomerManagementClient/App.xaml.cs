using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CustomersBLL.Api;
using CustomersBLL.Services;
using Refit;

namespace CustomerManagementClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
        public App()
        {
            
        }

        private static ServiceProvider BuildServiceProvider(
            IConfigurationRoot configuration)
        {
            var services = new ServiceCollection();
            ConfigureServices(configuration, services);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private static void ConfigureServices(
            IConfigurationRoot configuration,
            IServiceCollection services)
        {
            services.AddRefitClient<ICustomersApi>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(configuration["CustomersApi:BaseAddress"]);
                });
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<MainWindow>();
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            IConfigurationRoot configuration = BuildConfiguration();
            BuildConfiguration();
            var serviceProvider = BuildServiceProvider(configuration);
            
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
