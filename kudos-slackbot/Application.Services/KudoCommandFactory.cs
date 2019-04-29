namespace KudosSlackbot.Application.Services
{
    using System;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;

    using MediatR;

    public class KudoCommandFactory : IKudoCommandFactory
    {
        public IRequest<SlashCommandResponseDto> CreateKudoCommand(SlashCommandDto slashCommandDto)
        {
            if (slashCommandDto == null || string.IsNullOrWhiteSpace(slashCommandDto.text))
            {
                throw new ArgumentException("Kudo command should not be null");
            }

            var actionString = slashCommandDto.text.Split(' ')[0];

            var commandAction = Enum.Parse(typeof(EKudoCommandAction), actionString, ignoreCase: true);
            IKudoCommand kudoCommand;
            switch (commandAction)
            {
                case EKudoCommandAction.Add:
                    kudoCommand = new CreateKudoCommand();
                    this.FillBaseKudoCommandProperties(kudoCommand, slashCommandDto);
                    break;
                case EKudoCommandAction.Help:
                    kudoCommand = new HelpKudoCommand();
                    this.FillBaseKudoCommandProperties(kudoCommand, slashCommandDto);
                    break;
                default:
                    throw new ArgumentException("Invalid kudo command. Use </kudos help> for options");
            }

            return kudoCommand;
        }

        private void FillBaseKudoCommandProperties(IKudoCommand kudoCommand, SlashCommandDto slashCommandDto)
        {
            kudoCommand.UserId = slashCommandDto.user_id;
            kudoCommand.Username = slashCommandDto.user_name;
            kudoCommand.ChannelId = slashCommandDto.channel_id;
            kudoCommand.ChannelName = slashCommandDto.channel_name;
            kudoCommand.Text = slashCommandDto.text;
        }
    }
}