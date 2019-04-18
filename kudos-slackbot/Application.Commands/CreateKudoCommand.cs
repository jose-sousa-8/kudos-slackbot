namespace KudosSlackbot.Application.Commands
{
    public class CreateKudoCommand : IKudoCommand
    {
        public string Text { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string ChannelId { get; set; }

        public string ChannelName { get; set; }
    }
}
