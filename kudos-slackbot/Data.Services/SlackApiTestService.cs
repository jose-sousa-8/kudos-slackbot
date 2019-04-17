namespace KudosSlackbot.Data.Services
{
    using System;
    using System.Threading.Tasks;

    using KudosSlackbot.Data.Gateway.Slack;

    public class SlackApiTestService : ISlackApiTestService
    {
        private readonly ISlackApiTestGateway testSlackApiGateway;

        public SlackApiTestService(ISlackApiTestGateway testSlackApiGateway)
        {
            this.testSlackApiGateway = testSlackApiGateway;
        }

        public async Task<object> TestSlackApi()
        {
            try
            {
                return await testSlackApiGateway.TestSlackApi();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
