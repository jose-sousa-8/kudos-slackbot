namespace KudosSlackbot.Presentation.Api
{
    using Data.Repository;

    using KudosSlackbot.Application.Services;
    using KudosSlackbot.Client.Http.Slack.Clients;
    using KudosSlackbot.Data.Gateway.Slack;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Infrastructure.Settings.Slack;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KudoContext>(options => options.UseSqlServer("Server=localhost;Database=kudos-slackbot;Integrated Security=SSPI;"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            this.ConfigureSwagger(services);

            var slackSettings = Configuration.GetSection("SlackSettings").Get<SlackSettings>();

            services.AddTransient<ISlackApiTestClient>((factory) => new SlackApiTestClient(slackSettings.SlackApiEndpoint, slackSettings.SlackCredentials.OAuthToken));
            services.AddTransient<ISlackUsersClient>((factory) => new SlackUsersClient(slackSettings.SlackApiEndpoint, slackSettings.SlackCredentials.OAuthToken));

            services.AddTransient<ISlackApiTestGateway, SlackApiTestGateway>();
            services.AddTransient<ISlackApiTestService, SlackApiTestService>();

            services.AddTransient<ISlackUsersGateway, SlackUsersGateway>();
            services.AddTransient<ISlackUsersService, SlackUsersService>();

            services.AddTransient<IKudoCommandFactory, KudoCommandFactory>();
            services.AddTransient<IKudoRepository, KudoRepository>();
            services.AddTransient<IKudoService, KudoService>();

            this.ConfigureCQRS(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            this.ConfigureSwagger(app);
        }
    }
}