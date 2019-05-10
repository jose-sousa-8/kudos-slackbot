namespace KudosSlackbot.Application.Dto.Slack.SlashCommands
{
    using global::Slack.Common;

    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class SlackResponseMessage : ISlackResponseMessage
    {
        public MessagePayload Payload { get; set; }
    }
}
