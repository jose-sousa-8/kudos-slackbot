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

    public class ReplaceKudoCommandHandler : IRequestHandler<ReplaceKudoCommand, IEnumerable<LayoutBlock>>
    {
        private readonly IKudoService kudoService;

        public ReplaceKudoCommandHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<IEnumerable<LayoutBlock>> Handle(ReplaceKudoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<ReplaceKudoCommand>.GetValidator().Validate(request);

                var kudo = new Domain.Model.Kudo
                {
                    Id = int.Parse(request.CommandText.Split(' ')[1]),
                    CommandText = request.CommandText
                };

                return Task.FromResult(kudoService.ReplaceKudo(kudo).Payload.Blocks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
