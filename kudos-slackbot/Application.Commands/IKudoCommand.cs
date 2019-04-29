namespace KudosSlackbot.Application.Commands
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;

    using MediatR;

    public interface IKudoCommand : IRequest<SlashCommandResponseDto>
    {
        string Text { get; set; }

        string UserId { get; set; }

        string Username { get; set; }

        string ChannelId { get; set; }

        string ChannelName { get; set; }
    }
}
