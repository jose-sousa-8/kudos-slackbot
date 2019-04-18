namespace KudosSlackbot.Application.Services
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;

    using MediatR;

    public interface IKudoCommandFactory
    {
        IRequest<SlashCommandResponseDto> CreateKudoCommand(SlashCommandDto slashCommandDto);
    }
}
