﻿namespace KudosSlackbot.Data.Services
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
            kudo.Text = kudo.GetKudoMessage(2);

            kudoRepository.Create(kudo.Map<Dbo.Kudo>());

            return new SlashCommandResponseDto
            {
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto{
                        text = $"You given a friend a kudo! You're a warrior of god! :jesus:"
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
                        text = $@"*Available commands:*{Environment.NewLine}
                                   /kudo <add> <user-id> <text>{Environment.NewLine}
                                   /kudo <help>{Environment.NewLine}
                                   /kudo list <*/n>{Environment.NewLine}
                                   /kudo delete <kudo-id>{Environment.NewLine}
                                   /kudo replace <kudo-id> <new-text>"
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
            if (!kudos.Any())
            {
                return new SlashCommandResponseDto
                {
                    Attachments = new List<AttachmentDto>
                    {
                        new AttachmentDto
                        {
                            text = "You don't have a single kudo. You pretty much suck! :wink:"
                        }
                    }
                };
            }

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

        public ISlashCommandResponse ReplaceKudo(Kudo kudo)
        {
            kudo.Text = kudo.GetKudoMessage(2);

            this.kudoRepository.UpdateText(kudo.Map<Dbo.Kudo>());

            return new SlashCommandResponseDto
            {
                Attachments = new List<AttachmentDto>
                {
                    new AttachmentDto
                    {
                        text = "You changed them kudo! You did better this time? :thinking_face:"
                    }
                }
            };
        }
    }
}
