using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Messaging;
using ServiceStack.RabbitMq;

[assembly: HostingStartup(typeof(Stackers.ConfigureMq))]

namespace Stackers
{
    /**
      Register Services you want available via MQ in your AppHost, e.g:
        var mqServer = appHost.Resolve<IMessageService>();
        mqServer.RegisterHandler<MyRequest>(ExecuteMessage);
    */
    public class ConfigureMq : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices((context, services) => {
                services.AddSingleton<IMessageService>(c => 
                    new RabbitMqServer(context.Configuration.GetConnectionString("RabbitMq") ?? "localhost:5672"));
            })
            .ConfigureAppHost(afterAppHostInit: appHost => {
                appHost.Resolve<IMessageService>().Start();
            });
    }
}
