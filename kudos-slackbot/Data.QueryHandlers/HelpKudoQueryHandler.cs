namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Data.Services;

    using MediatR;

    using Slack.Common;

    public class HelpKudoQueryHandler : IRequestHandler<HelpKudoQuery, ISlackResponseMessage>
    {
        private readonly IKudoService kudoService;

        public HelpKudoQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlackResponseMessage> Handle(HelpKudoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(kudoService.BuildHelpResponse());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
