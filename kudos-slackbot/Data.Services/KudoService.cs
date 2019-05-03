namespace KudosSlackbot.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using KudosSlackbot.Application.Dto.Slack.Channel;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Data.Repository;
    using KudosSlackbot.Data.Services.Extensions;
    using KudosSlackbot.Domain.Model;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class KudoService : IKudoService
    {
        private readonly IKudoRepository kudoRepository;

        public KudoService(IKudoRepository kudoRepository)
        {
            this.kudoRepository = kudoRepository;
        }

        public ISlashCommandResponse CreateKudo(Kudo kudo)
        {
            kudo.Text = kudo.GetAddKudoMessage();

            kudoRepository.Create(kudo.Map<Dbo.Kudo>());

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

        public ISlashCommandResponse BuildHelpResponse()
        {
            return new SlashCommandResponseDto
            {
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto
                    {
                        text = $@"*Available commands:*{Environment.NewLine}/kudos <add> <user-id> <text>{Environment.NewLine}/kudos <help>{Environment.NewLine}/kudos list <*/n>{Environment.NewLine}/kudos delete <kudo-id>"
                    }
                }
            };
        }

        public ISlashCommandResponse GetNKudosByUserId(Kudo kudo)
        {
            var numberOfKudos = kudo.CommandText.Split(' ')[1];

            if (numberOfKudos == "*")
            {
                return this.GetAllUserKudos(kudo.UserId);
            }

            var kudos = this.kudoRepository.GetNByUserId(kudo.UserId, Convert.ToInt32(numberOfKudos)).Select(x => x.Map<Kudo>());

            return this.BuildSlashResponseFromKudoList(kudos);
        }

        public ISlashCommandResponse GetAllUserKudos(string userId)
        {
            var kudos = this.kudoRepository.GetAllByUserId(userId).Select(x => x.Map<Kudo>());

            return this.BuildSlashResponseFromKudoList(kudos);
        }

        private ISlashCommandResponse BuildSlashResponseFromKudoList(IEnumerable<Kudo> kudos)
        {
            var textBuild = new StringBuilder();

            var lastIndex = kudos.Count() - 1;

            for (int i = 0; i < kudos.Count(); i++)
            {

                textBuild.Append($"{kudos.ElementAt(i).ByUsername} - {kudos.ElementAt(i).Text}");
                if (i != lastIndex)
                {
                    textBuild.Append(Environment.NewLine);
                }
            }

            return new SlashCommandResponseDto
            {
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto
                    {
                        text = textBuild.ToString()
                    }
                }
            };
        }

        public ISlashCommandResponse DeleteKudo(Guid kudoId)
        {
            this.kudoRepository.Delete(kudoId);

            return new SlashCommandResponseDto
            {
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto
                    {
                        text = "You deleted a kudo! You bastard! :angry:"
                    }
                }
            };
        }
    }
}
