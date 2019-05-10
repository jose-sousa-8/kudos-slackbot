namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using MediatR;

    public class HelpKudoCommandHandler : IRequestHandler<HelpKudoQuery, ISlackResponseMessage>
    {
        private readonly IKudoService kudoService;

        public HelpKudoCommandHandler(IKudoService kudoService)
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
                throw ex;
            }
        }
    }
}
