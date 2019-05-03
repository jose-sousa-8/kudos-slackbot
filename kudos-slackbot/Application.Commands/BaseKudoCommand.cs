namespace KudosSlackbot.Application.Commands
{
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public abstract class BaseKudoCommand : IKudoRequest
    {
        public string Text { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string ChannelId { get; set; }

        public string ChannelName { get; set; }
    }
}
