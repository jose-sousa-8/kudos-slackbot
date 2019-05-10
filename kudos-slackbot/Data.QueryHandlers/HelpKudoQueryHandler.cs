namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Data.Services;

    using MediatR;

    using Slack.Common.LayoutBlocks;

    public class HelpKudoQueryHandler : IRequestHandler<HelpKudoQuery, IEnumerable<LayoutBlock>>
    {
        private readonly IKudoService kudoService;

        public HelpKudoQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<IEnumerable<LayoutBlock>> Handle(HelpKudoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(kudoService.BuildHelpResponse().Payload.Blocks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
