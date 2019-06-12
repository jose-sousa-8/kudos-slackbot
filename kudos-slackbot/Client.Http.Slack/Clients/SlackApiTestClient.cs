namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class SlackApiTestClient : SlackBaseClient, ISlackApiTestClient
    {
        protected override string SlackApiEndpoint { get; set; }

        private static readonly string ApiTestMethod = "api.test";

        public SlackApiTestClient(string slackApiEndpoint, string oAuthToken) : base(oAuthToken)
        {
            this.SlackApiEndpoint = slackApiEndpoint;
        }

        public async Task<object> TestApi()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var userInfoUri = new Uri(string.Format("{0}{1}", this.SlackApiEndpoint, ApiTestMethod));

                    var request = base.GenerateBasicRequest(userInfoUri, HttpMethod.Post);

                    var response = await httpClient.SendAsync(request);

                    return await base.ProcessResponse<object>(response);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
