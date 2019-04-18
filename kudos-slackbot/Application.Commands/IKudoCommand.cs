namespace KudosSlackbot.Application.Commands
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;

    using MediatR;

    public interface IKudoCommand : IRequest<SlashCommandResponseDto>
    {
    }
}
