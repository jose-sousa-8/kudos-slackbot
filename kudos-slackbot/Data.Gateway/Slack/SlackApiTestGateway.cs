namespace KudosSlackbot.Data.Gateway.Slack
{
    using System;
    using System.Threading.Tasks;

    using KudosSlackbot.Client.Http.Slack.Clients;

    public class SlackApiTestGateway : ISlackApiTestGateway
    {
        private readonly ISlackApiTestClient slackApiTestClient;

        public SlackApiTestGateway(ISlackApiTestClient slackApiTestClient)
        {
            this.slackApiTestClient = slackApiTestClient;
        }

        public async Task<object> TestSlackApi()
        {
            try
            {
                return await this.slackApiTestClient.TestApi();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
