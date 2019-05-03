﻿namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using MediatR;

    public class HelpKudoQueryHandler : IRequestHandler<HelpKudoQuery, ISlashCommandResponse>
    {
        private readonly IKudoService kudoService;

        public HelpKudoQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlashCommandResponse> Handle(HelpKudoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(kudoService.BuildHelpResponse());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}