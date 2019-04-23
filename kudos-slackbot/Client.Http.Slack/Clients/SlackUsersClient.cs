namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.WebUtilities;

    using Newtonsoft.Json;

    public class SlackUsersClient : SlackBaseClient, ISlackUsersClient
    {
        private const string Method = "users.info";

        public SlackUsersClient(string slackApiEndpoint) : base(slackApiEndpoint, Method)
        {
        }


        public async Task<UserInfoSlackHttpResponse> GetUserInfo(string userId, bool includeLocal = false)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var queryParameters = new Dictionary<string, string>
                    {
                        {"user", userId },
                        {"include_local", includeLocal.ToString() }
                    };

                    var response = await httpClient.GetAsync(QueryHelpers.AddQueryString(base.SlackApiUri.ToString(), queryParameters));

                    var byteArr = await response.Content.ReadAsByteArrayAsync();

                    var json = Encoding.UTF8.GetString(byteArr);

                    return JsonConvert.DeserializeObject<UserInfoSlackHttpResponse>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
