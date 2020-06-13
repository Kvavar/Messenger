using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Messenger.Infrastructure.Users;
using Messenger.Infrastructure.Messages;
using Messenger.Infrastructure.Configuration.Options;
using Microsoft.Extensions.Options;
using Pricer.IexCloudProvider;

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
            services.Configure<UserQueueOptions>(options => Configuration.GetSection(userQueueOptions.SectionName).Bind(options));
            services.AddSingleton<IUserQueue, UserQueue>();
            services.AddSingleton<IMessageQueue, MessageQueue>();
            services.AddHttpClient<IexCloudHttpClient, IexCloudHttpClient>();
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
