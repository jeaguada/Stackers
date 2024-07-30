using ServiceStack;

[assembly: HostingStartup(typeof(Stackers.ConfigureServerEvents))]

namespace Stackers;

public class ConfigureServerEvents : IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            services.AddPlugin(new ServerEventsFeature());
        });
}
