namespace KudosSlackbot.Infrastructure.Settings.Slack
{
    public class SlackCredentials
    {
        public string AppId { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string SigningSecret { get; set; }

        public string VerificationToken { get; set; }
    }
}
