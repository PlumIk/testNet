using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace testNet
{
    public class ClassT1 : IHostedService
    {
        private bool _running = true;
        public ClassT1()
        {
            Console.WriteLine("1 is do");
        }

        public void MyFun()
        {
            while (_running)
            {
                Console.WriteLine("IWork");
                Thread.Sleep(1000);
            }
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(MyFun);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _running = false;
            return Task.CompletedTask;
        }
    }
}