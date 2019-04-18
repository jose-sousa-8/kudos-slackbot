namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;
    using MediatR;

    public class CreateKudoCommandHandler : IRequestHandler<CreateKudoCommand, SlashCommandResponseDto>
    {
        private readonly IKudoService kudoService;

        public CreateKudoCommandHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<SlashCommandResponseDto> Handle(CreateKudoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = KudoSlashCommandValidatorFactory.GetValidator(request);

                validator.Validate();

                var kudo = new Domain.Model.Kudo
                {
                    ByUserId = request.UserId,
                    ByUsername = request.Username,
                    ChannelId = request.ChannelId,
                    ChannelName = request.ChannelName,
                    CommandText = request.Text
                };

                var id = kudoService.CreateKudo(kudo);

                return Task.FromResult(new SlashCommandResponseDto());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
