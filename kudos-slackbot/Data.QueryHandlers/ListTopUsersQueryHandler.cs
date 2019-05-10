namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using MediatR;

    public class ListTopUsersQueryHandler : IRequestHandler<ListTopUsersQuery, ISlackResponseMessage>
    {
        private readonly IKudoService kudoService;

        public ListTopUsersQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlackResponseMessage> Handle(ListTopUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<ListTopUsersQuery>.GetValidator().Validate(request);

                var nUsers = request.Text.Split(' ')[1];
                return Task.FromResult(kudoService.GetTopUsers(nUsers));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
