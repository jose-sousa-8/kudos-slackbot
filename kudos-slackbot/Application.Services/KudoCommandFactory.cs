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

            if (Enum.TryParse<EKudoCommandAction>(actionString, true, out var commandAction))
            {
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
                        throw new ArgumentException("Invalid kudo command");
                }
            }
            else
            {
                throw new ArgumentException("Invalid kudo command");
            }
        }
    }
}