namespace KudosSlackbot.Presentation.Api
{
    using KudosSlackbot.Data.CommandHandlers;
    using KudosSlackbot.Data.QueryHandlers;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        public void ConfigureCQRS(IServiceCollection services)
        {
            // Mediator
            services.AddMediatR(typeof(SlackApiTestQueryHandler).Assembly, typeof(CreateKudoCommandHandler).Assembly);
        }
    }
}