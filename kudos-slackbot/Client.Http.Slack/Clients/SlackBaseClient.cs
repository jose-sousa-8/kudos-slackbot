namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;

    public abstract class SlackBaseClient
    {
        protected Uri SlackApiUri { get; set; }

        public SlackBaseClient(string slackApiEndpoint)
        {
            this.SlackApiUri = new Uri(slackApiEndpoint);
        }
    }
}
