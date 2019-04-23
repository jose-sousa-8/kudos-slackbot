namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

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

        protected virtual async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var byteArr = await response.Content.ReadAsByteArrayAsync();

            var json = Encoding.UTF8.GetString(byteArr);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
