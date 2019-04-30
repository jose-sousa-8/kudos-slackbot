namespace KudosSlackbot.Data.Services
{
    using System;
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Channel;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Data.Repository;
    using KudosSlackbot.Domain.Model;

    public class KudoService : IKudoService
    {
        private readonly IKudoRepository kudoRepository;

        public KudoService(IKudoRepository kudoRepository)
        {
            this.kudoRepository = kudoRepository;
        }

        public SlashCommandResponseDto CreateKudo(Kudo kudo)
        {
            kudoRepository.CreateKudo(kudo.Map<Dbo.Kudo>());

            return new SlashCommandResponseDto
            {
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto{
                        text = $"Kudaste um amigo! És um guerreiro de Deus! :jesus:"
                    }
                }
            };
        }

        public SlashCommandResponseDto BuildHelpResponse()
        {
            return new SlashCommandResponseDto
            {
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto
                    {
                        text = $@"*Available commands:*{Environment.NewLine}/kudos <add> <user-id> <text>{Environment.NewLine}/kudos <help>"
                    }
                }
            };
        }
    }
}
