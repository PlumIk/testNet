using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace testNet
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("here");
           CreateHostBuilder(null).Build().Run();
        }
        
        /*
        public static IHostBuilder CreateHostBuilder()

        {

        	

            return Host.CreateDefaultBuilder()

                .ConfigureServices((hostContext, services) =>

                {

                    services.AddHostedService<ClassT1>();

                });

        }
        
    }
    */
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddHostedService<MessageWriterService>()
                            .AddSingleton<IMessageWriter, ConsoleMessageWriter>());

    interface IMessageWriter
    {
        public void Write(string message);
    }


    class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        
    }
    class MessageWriterService : IHostedService
    {
        private bool _running = true;
        IMessageWriter _writer;
        public MessageWriterService(IMessageWriter writer) => _writer = writer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(RunAsync);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void RunAsync()
        {
            while (_running)
            {
                _writer.Write("I'm aive");
                Thread.Sleep(1000);
            }
        }
    }


}

    
    
    
    
    
}