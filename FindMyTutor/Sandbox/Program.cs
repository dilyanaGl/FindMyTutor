namespace Sandbox
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using CommandLine;
    using FindMyTutor.Data;
    using FindMyTutor.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;


    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            // Seed data on application startup
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<FindMyTutorWebContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                return Parser.Default.ParseArguments<SandboxOptions>(args).MapResult(
                    opts => SandboxCode(opts, serviceProvider),
                    _ => 255);
            }
        }

        private static int SandboxCode(SandboxOptions options, IServiceProvider serviceProvider)
        {


            var mathSubjects = new List<string[]> {

                new string[]{ "Университет", "Линейна алгебра"},
               new string[]{ "Университет", "Анализ на алгоритми"},
               new string[]{ "Университет", "Дискретна математика"},
               new string[]{ "Университет", "Висша алгебра"},
               new string[]{ "Гимназия", "Подготовка за матура"},
               new string[]{ "Основно училище", "Подготовка за изпит за кандидатване в 7. клас"},
               new string[]{ "Гимназия", "Тригонометрия"},
            };



            var  litSubjects = new List<string[]> {

                new string[]{ "Гимназия", "Подготовка за матура"},
               new string[]{ "Основно училище", "Подготовка за изпит за кандидатване в 7. клас"},
               new string[]{ "Гимназия", "Писане на интерпретативно съчинение"},
      
            };


            var english = new List<string[]> {

                new string[]{ "Гимназия", "Подготовка за матура"},
               new string[]{ "Гимназия", "Подготовка за TOEFL"},
               new string[]{ "Гимназия", "Подготовка за SAT"},

            };


            //var sw = Stopwatch.StartNew();
            ////var settingsService = serviceProvider.
            ///<ISettingsService>();
            //Console.WriteLine($"Count of settings: {settingsService.GetCount()}");
            //Console.WriteLine(sw.Elapsed);
            return 0;
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddDbContext<FindMyTutorWebContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseLoggerFactory(new LoggerFactory()));

            //services
            //    .AddIdentity<FindMyTutorUser, Role>(options =>
            //    {
            //        options.Password.RequireDigit = false;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequireUppercase = false;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequiredLength = 6;
            //    })
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddUserStore<ApplicationUserStore>()
            //    .AddRoleStore<ApplicationRoleStore>()
            //    .AddDefaultTokenProviders();

            //services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            //// Application services
            //services.AddTransient<IEmailSender, NullMessageSender>();
            //services.AddTransient<ISmsSender, NullMessageSender>();
            //services.AddTransient<ISettingsService, SettingsService>();
        }
    }
}
