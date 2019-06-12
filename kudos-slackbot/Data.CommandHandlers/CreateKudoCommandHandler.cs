namespace KudosSlackbot.Data.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Services.Extensions;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;

    using MediatR;

    using Slack.Common;

    public class CreateKudoCommandHandler : IRequestHandler<CreateKudoCommand, ISlackResponseMessage>
    {
        private readonly IKudoService kudoService;

        public CreateKudoCommandHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlackResponseMessage> Handle(CreateKudoCommand request, CancellationToken cancellationToken)
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
                throw;
            }
        }
    }
}
