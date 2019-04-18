namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Data.Repository;

    using MediatR;

    public class CreateKudoCommandHandler : IRequestHandler<CreateKudoCommand, SlashCommandResponseDto>
    {
        private readonly IKudoRepository kudoRepository;

        public CreateKudoCommandHandler(IKudoRepository kudoRepository)
        {
            this.kudoRepository = kudoRepository;
        }

        public Task<SlashCommandResponseDto> Handle(CreateKudoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var kudo = new Domain.Model.Kudo
                {
                    ByUserId = request.UserId,
                    ByUsername = request.Username,
                    ChannelId = request.ChannelId,
                    ChannelName = request.ChannelName,
                    CommandText = request.Text
                };

                var id = kudoRepository.CreateKudo(kudo.Map<Data.Dbo.Kudo>());

                return Task.FromResult(new SlashCommandResponseDto());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
