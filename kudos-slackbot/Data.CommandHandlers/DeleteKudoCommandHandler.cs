namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;

    using MediatR;

    using Slack.Common.LayoutBlocks;

    public class DeleteKudoCommandHandler : IRequestHandler<DeleteKudoCommand, IEnumerable<LayoutBlock>>
    {
        private readonly IKudoService kudoService;

        public DeleteKudoCommandHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<IEnumerable<LayoutBlock>> Handle(DeleteKudoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<DeleteKudoCommand>.GetValidator().Validate(request);

                var kudoId = int.Parse(request.CommandText.Split(' ')[1]);

                return Task.FromResult(kudoService.DeleteKudo(kudoId).Payload.Blocks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
