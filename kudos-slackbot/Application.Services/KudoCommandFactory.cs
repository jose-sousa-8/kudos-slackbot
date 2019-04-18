namespace KudosSlackbot.Application.Services
{
    using System;
    using System.Text.RegularExpressions;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;

    using MediatR;

    public class KudoCommandFactory : IKudoCommandFactory
    {
        private const string SlackIdRegex = "^(<@U)[a-zA-Z0-9]*>";

        public IRequest<SlashCommandResponseDto> CreateKudoCommand(SlashCommandDto slashCommandDto)
        {
            var actionString = slashCommandDto.text.Split(' ')[0];

            var parsed = Enum.TryParse<EKudoCommandAction>(actionString, true, out var commandAction);

            if (!parsed)
            {
                throw new ArgumentException("Invalid kudo command");
            }

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
                default:
                    throw new ArgumentException("Invalid kudo command provided.");
            }
        }

        private EKudoCommandAction ValidateSlashCommand(SlashCommandDto slashCommandDto)
        {
            if (slashCommandDto == null || string.IsNullOrWhiteSpace(slashCommandDto.text))
            {
                throw new ArgumentException("Invalid kudo command");
            }


            this.ValidateCommandAction(slashCommandDto, commandAction);

            return commandAction;
        }

        private void ValidateCommandAction(SlashCommandDto slashCommandDto, EKudoCommandAction commandAction)
        {
            switch (commandAction)
            {
                case EKudoCommandAction.Add:
                    this.ValidateAddCommandAction(slashCommandDto);
                    break;
                default:
                    throw new NotImplementedException("Only the \"add\" kudo command is available for now.");
            }
        }

        private void ValidateAddCommandAction(SlashCommandDto slashCommandDto)
        {
            var parcels = slashCommandDto.text.Split(' ');

            if (parcels.Length < 3)
            {
                throw new ArgumentException("Invalid kudo add command. It should be in format /kudo add <slack-id> <text>");
            }

            var slackId = parcels[1];

            if (!Regex.Match(slackId, SlackIdRegex).Success)
            {
                throw new ArgumentException("Invalid User Id.");
            }
        }
    }
}
