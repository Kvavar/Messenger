using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Messenger.Infrastructure.Users;
using Messenger.Infrastructure.Messages;
using Messenger.Infrastructure.Configuration.Options;
using Messenger.Infrastructure.Configuration.Options.Pricers;
using Pricer.IexCloudProvider;
using Pricer.IexCloudProvider.IexReferenceData;
using Pricer.IexCloudProvider.IexStock;

namespace Messenger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var userQueueOptions = new UserQueueOptions();
            var iexPricerOptions = new IexPricerOptions();
            services.Configure<UserQueueOptions>(options => Configuration.GetSection(userQueueOptions.SectionName).Bind(options));
            services.Configure<IexPricerOptions>(options => Configuration.GetSection(iexPricerOptions.SectionName).Bind(options));
            services.AddSingleton<IUserQueue, UserQueue>();
            services.AddSingleton<IMessageQueue, MessageQueue>();
            services.AddHttpClient<IIexHttpClient, IexHttpClient>();
            services.AddScoped<IIexProvider, IexProvider>();
            services.AddScoped<IIexReferenceDataProvider, IexReferenceDataProvider>();
            services.AddScoped<IIexOptionProvider,IexOptionProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
