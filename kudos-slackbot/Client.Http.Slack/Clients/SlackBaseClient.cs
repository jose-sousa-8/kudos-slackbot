namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.WebUtilities;

    using Newtonsoft.Json;

    public abstract class SlackBaseClient
    {
        protected abstract string SlackApiEndpoint { get; set; }

        protected string OAuthToken { get; private set; }

        public SlackBaseClient(string oAuthToken)
        {
            this.OAuthToken = oAuthToken;
        }

        protected virtual async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var byteArr = await response.Content.ReadAsByteArrayAsync();

            var json = Encoding.UTF8.GetString(byteArr);

            return JsonConvert.DeserializeObject<T>(json);
        }

        protected virtual HttpRequestMessage GenerateAuthenticatedRequest(Uri uri, HttpMethod method, IDictionary<string, string> queryParameters = null)
        {
            var httpRequestMessage = new HttpRequestMessage();

            string uriString = uri.ToString();

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.OAuthToken);

            if (method == HttpMethod.Get && queryParameters != null)
            {
                uriString = QueryHelpers.AddQueryString(uri.ToString(), queryParameters);
            }

            httpRequestMessage = new HttpRequestMessage(method, uriString);

            return httpRequestMessage;
        }


        protected virtual HttpRequestMessage GenerateBasicRequest(Uri uri, HttpMethod method, IDictionary<string, string> queryParameters = null)
        {
            string uriString = uri.ToString();

            if (method == HttpMethod.Get && queryParameters != null)
            {
                uriString = QueryHelpers.AddQueryString(uri.ToString(), queryParameters);
            }

            return new HttpRequestMessage(method, uriString);
        }
    }
}
