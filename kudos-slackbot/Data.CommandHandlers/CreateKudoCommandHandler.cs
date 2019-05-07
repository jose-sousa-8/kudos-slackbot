namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Services.Extensions;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using MediatR;

    public class CreateKudoCommandHandler : IRequestHandler<CreateKudoCommand, ISlashCommandResponse>
    {
        private readonly IKudoService kudoService;

        public CreateKudoCommandHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlashCommandResponse> Handle(CreateKudoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<CreateKudoCommand>.GetValidator().Validate(request);

                var kudo = new Domain.Model.Kudo
                {
                    UserId = request.GetUserId(),
                    Username = request.GetUsername(),
                    ByUserId = request.UserId,
                    ByUsername = request.Username,
                    ChannelId = request.ChannelId,
                    ChannelName = request.ChannelName,
                    CommandText = request.Text
                };

                return Task.FromResult(kudoService.CreateKudo(kudo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
