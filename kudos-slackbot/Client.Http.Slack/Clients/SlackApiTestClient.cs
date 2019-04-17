namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public class SlackApiTestClient : SlackBaseClient, ISlackApiTestClient
    {
        private const string apiTestMethod = "api.test";

        public SlackApiTestClient(string slackApiEndpoint) : base(slackApiEndpoint)
        {
        }

        public async Task<object> TestApi()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.PostAsync(string.Format("{0}{1}", base.SlackApiUri, apiTestMethod), null);

                    var byteArr = await response.Content.ReadAsByteArrayAsync();

                    var json = Encoding.UTF8.GetString(byteArr);

                    return JsonConvert.DeserializeObject<BaseSlackHttpResponse>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
