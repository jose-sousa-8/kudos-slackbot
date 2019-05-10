namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;

    using MediatR;

    using Slack.Common;

    public class DeleteKudoCommandHandler : IRequestHandler<DeleteKudoCommand, ISlackResponseMessage>
    {
        private readonly IKudoService kudoService;

        public DeleteKudoCommandHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlackResponseMessage> Handle(DeleteKudoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<DeleteKudoCommand>.GetValidator().Validate(request);

                var kudoId = int.Parse(request.CommandText.Split(' ')[1]);

                return Task.FromResult(kudoService.DeleteKudo(kudoId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
