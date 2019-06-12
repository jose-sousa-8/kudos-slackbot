namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Application.Queries;

    using KudosSlackbot.Data.Services;

    using MediatR;

    public class SlackApiTestQueryHandler : IRequestHandler<TestSlackApiQuery, object>
    {
        private readonly ISlackApiTestService slackApiTestService;

        public SlackApiTestQueryHandler(ISlackApiTestService slackApiTestService)
        {
            this.slackApiTestService = slackApiTestService;
        }

        public async Task<object> Handle(TestSlackApiQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await slackApiTestService.TestSlackApi();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
