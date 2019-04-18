namespace KudosSlackbot.Application.Commands
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;

    using MediatR;

    public class CreateKudoCommand : IRequest<SlashCommandResponseDto>
    {
        public string Text { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string ChannelId { get; set; }

        public string ChannelName { get; set; }
    }
}
