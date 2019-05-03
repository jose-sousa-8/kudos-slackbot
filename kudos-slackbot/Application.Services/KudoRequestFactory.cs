namespace KudosSlackbot.Application.Services
{
    using System;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using MediatR;

    public class KudoRequestFactory : IKudoRequestFactory
    {
        public IRequest<ISlashCommandResponse> CreateKudoCommand(SlashCommandDto slashCommandDto)
        {
            if (slashCommandDto == null || string.IsNullOrWhiteSpace(slashCommandDto.text))
            {
                throw new ArgumentException("Kudo command should not be null");
            }

            var actionString = slashCommandDto.text.Split(' ')[0];

            var commandAction = Enum.Parse(typeof(EKudoCommandAction), actionString, ignoreCase: true);
            switch (commandAction)
            {
                case EKudoCommandAction.Add:
                    return new CreateKudoCommand
                    {
                        UserId = slashCommandDto.user_id,
                        Username = slashCommandDto.user_name,
                        ChannelId = slashCommandDto.channel_id,
                        ChannelName = slashCommandDto.channel_name,
                        Text = slashCommandDto.text
                    };
                case EKudoCommandAction.Help:
                    return new HelpKudoQuery();
                default:
                    throw new ArgumentException("Invalid kudo command. Use </kudos help> for options");
            }
        }
    }
}