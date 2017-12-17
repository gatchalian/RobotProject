using System;
using System.IO;
using System.Linq;
using Autofac;
using Microsoft.Extensions.Configuration;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Consumers;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadConfiguration();
            if (args.Length > 0)
            {
                var fileConsumer = RegistrationService.Container.ResolveKeyed<IConsumers>(nameof(FileTextConsumer));
                fileConsumer.StartProcessing(args.FirstOrDefault());
            }
            else
            {
                var consumer = RegistrationService.Container.ResolveKeyed<IConsumers>(nameof(ConsoleTextConsumer));
                consumer.StartProcessing(string.Empty);
            }
            Console.WriteLine("DONE.. press any key to terminate");
            Console.ReadKey();
        }

        private static void LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

   
            RegistrationService.TableWidth = int.Parse(configuration["table:width"]);
            RegistrationService.TableHeight = int.Parse(configuration["table:height"]);
            RegistrationService.LateralSpeed = int.Parse(configuration["lateralspeed"]);
            RegistrationService.Register();
        }
    }
}
