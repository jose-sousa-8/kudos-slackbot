namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Application.Services.Extensions;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using MediatR;

    public class ListUserKudosQueryHandler : IRequestHandler<ListUserKudosQuery, ISlashCommandResponse>
    {
        private readonly IKudoService kudoService;

        public ListUserKudosQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlashCommandResponse> Handle(ListUserKudosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<ListUserKudosQuery>.GetValidator().Validate(request);

                return Task.FromResult(kudoService.GetAllUserKudos(request.GetUserId()));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
