using Microsoft.AspNetCore.Components.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace SpotIt.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<HubConnectionBuilder>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
