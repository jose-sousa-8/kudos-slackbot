namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;

    public abstract class SlackBaseClient
    {
        protected Uri SlackApiUri { get; set; }

        public SlackBaseClient(string slackApiEndpoint) : this(slackApiEndpoint, string.Empty)
        {
        }

        public SlackBaseClient(string slackApiEndpoint, string slackMethod)
        {
            this.SlackApiUri = new Uri(string.Format("{0}{1}", slackApiEndpoint, slackMethod));
        }
    }
}
