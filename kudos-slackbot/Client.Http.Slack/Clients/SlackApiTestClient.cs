namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class SlackApiTestClient : SlackBaseClient, ISlackApiTestClient
    {
        private const string apiTestMethod = "api.test";

        public SlackApiTestClient(string slackApiEndpoint) : base(slackApiEndpoint, apiTestMethod)
        {
        }

        public async Task<object> TestApi()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.PostAsync(base.SlackApiUri, null);

                    return await base.ProcessResponse<object>(response);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
