namespace KudosSlackbot.Infrastructure.CrossCutting.CQS
{
    using Slack.Common;

    public interface ISlackResponseMessage
    {
        MessagePayload Payload { get; set; }
    }
}
