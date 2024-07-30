using Stackers.ServiceInterface;
using ServiceStack.NativeTypes.TypeScript;

[assembly: HostingStartup(typeof(Stackers.AppHost))]

namespace Stackers;

public class AppHost() : AppHostBase("Stackers"), IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) => {
            // Configure ASP.NET Core IOC Dependencies
            services.AddSingleton(new AppConfig {
                AppBaseUrl = context.HostingEnvironment.IsDevelopment()
                    ? "https://localhost:5173"  
                    : null,
                ApiBaseUrl = context.HostingEnvironment.IsDevelopment()
                    ? "https://localhost:5001"  
                    : null,
            });
        });

    // Configure your AppHost with the necessary configuration and dependencies your App needs
    public override void Configure()
    {
        SetConfig(new HostConfig {
        });

        TypeScriptGenerator.InsertTsNoCheck = true;
    }
    
    // TODO: Replace with your own License Key. FREE Individual or OSS License available from: https://servicestack.net/free
    public static void RegisterKey() =>
        Licensing.RegisterLicense("OSS BSD-3-Clause 2024 https://github.com/NetCoreTemplates/vue-spa JV82wYhhnq0Hh6r5KBv1+9DTu6qGdZjZ7jlLulEzoqXmO1MEY7CiNqeXaSsE1Wn5SGZuqKViSXD2Hz6+bIO24+D0xFU/CW3CBKlRGpL4b2zVQAP2/b4QdzIEtELR3j7j755a3SasdJE/F7SlTorFyFSfCQwU2JVvoE9DPA+K0ZQ=");    
}
