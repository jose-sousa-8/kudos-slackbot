namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Application.Services.Extensions;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;

    using MediatR;

    using Slack.Common.LayoutBlocks;

    public class ListUserKudosQueryHandler : IRequestHandler<ListUserKudosQuery, IEnumerable<LayoutBlock>>
    {
        private readonly IKudoService kudoService;

        public ListUserKudosQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<IEnumerable<LayoutBlock>> Handle(ListUserKudosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<ListUserKudosQuery>.GetValidator().Validate(request);

                return Task.FromResult(kudoService.GetAllUserKudos(request.GetUserId()).Payload.Blocks);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
