namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Data.Services;

    using MediatR;

    public class HelpKudoCommandHandler : IRequestHandler<HelpKudoCommand, SlashCommandResponseDto>
    {
        private readonly IKudoService kudoService;

        public HelpKudoCommandHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<SlashCommandResponseDto> Handle(HelpKudoCommand request, CancellationToken cancellationToken)
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
