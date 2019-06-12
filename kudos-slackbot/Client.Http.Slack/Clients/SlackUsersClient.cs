namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class SlackUsersClient : SlackBaseClient, ISlackUsersClient
    {
        protected override string SlackApiEndpoint { get; set; }

        private static readonly string UserInfoMethod = "users.info";

        private static readonly string UserListMethod = "users.list";

        public SlackUsersClient(string slackApiEndpoint, string oAuthToken) : base(oAuthToken)
        {
            this.SlackApiEndpoint = slackApiEndpoint;
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

                    var userInfoUri = new Uri(string.Format("{0}{1}", this.SlackApiEndpoint, UserInfoMethod));

                    var request = base.GenerateAuthenticatedRequest(userInfoUri, HttpMethod.Get, queryParameters);

                    var response = await httpClient.SendAsync(request);

                    return await base.ProcessResponse<UserInfoSlackHttpResponse>(response);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<UsersListSlackHttpResponse> GetUserList()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var userListUri = new Uri(string.Format("{0}{1}", this.SlackApiEndpoint, UserListMethod));
                    var httpRequest = base.GenerateAuthenticatedRequest(userListUri, HttpMethod.Get);

                    var response = await httpClient.SendAsync(httpRequest);

                    return await base.ProcessResponse<UsersListSlackHttpResponse>(response);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
