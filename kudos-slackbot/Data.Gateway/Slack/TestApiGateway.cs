namespace KudosSlackbot.Data.Gateway.Slack
{
    using System;
    using System.Threading.Tasks;

    using KudosSlackbot.Client.Http.Slack.Clients;

    public class TestApiGateway
    {
        private readonly ISlackTestClient slackTestClient;

        public TestApiGateway(ISlackTestClient slackTestClient)
        {
            this.slackTestClient = slackTestClient;
        }

        public async Task<bool> TestSlackApi()
        {
            try
            {
                return await this.slackTestClient.TestApi();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
