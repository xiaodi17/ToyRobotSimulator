using System;
using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator.Robot.Robot;
using ToyRobotSimulator.Robot.Tabletop;

namespace ToyRobotSimulator
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<RobotSimulator>().Execute();
            DisposeServices();
        }
        
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRobot, ToyRobot>();
            services.AddSingleton<RobotSimulator>();
            services.AddSingleton<TabletopMap>();
            _serviceProvider = services.BuildServiceProvider(true);
        }
        
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
