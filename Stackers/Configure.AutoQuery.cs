using ServiceStack;

[assembly: HostingStartup(typeof(Stackers.ConfigureAutoQuery))]

namespace Stackers;

public class ConfigureAutoQuery : IHostingStartup
{
     public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            services.AddPlugin(new AutoQueryFeature {
               MaxLimit = 1000,
                IncludeTotal = true,
                GenerateCrudServices = new GenerateCrudServices {
                    AutoRegister = true,
                    //AddDataContractAttributes = false,
                }
            });
        });
}