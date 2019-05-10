namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;

    using MediatR;

    using Slack.Common.LayoutBlocks;

    public class ListTopUsersQueryHandler : IRequestHandler<ListTopUsersQuery, IEnumerable<LayoutBlock>>
    {
        private readonly IKudoService kudoService;

        public ListTopUsersQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<IEnumerable<LayoutBlock>> Handle(ListTopUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<ListTopUsersQuery>.GetValidator().Validate(request);

                var nUsers = request.Text.Split(' ')[1];
                return Task.FromResult(kudoService.GetTopUsers(nUsers).Payload.Blocks);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
