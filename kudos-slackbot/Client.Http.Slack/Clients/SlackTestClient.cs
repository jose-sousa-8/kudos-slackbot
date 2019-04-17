namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class SlackTestClient : SlackBaseClient, ISlackTestClient
    {
        private const string apiTestMethod = "api.test";

        public SlackTestClient(string slackApiEndpoint) : base(slackApiEndpoint)
        {
        }

        public async Task<bool> TestApi()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.PostAsync(string.Format("{0}{1}", base.SlackApiUri, apiTestMethod), null);

                    return response.StatusCode == System.Net.HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
