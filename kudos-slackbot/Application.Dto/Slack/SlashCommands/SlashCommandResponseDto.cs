namespace KudosSlackbot.Application.Dto.Slack.SlashCommands
{
    using global::Slack.Common;

    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class SlackResponseMessage : ISlackResponseMessage
    {
        public AttachmentsPayload Payload { get; set; }
    }
}
