namespace KudosSlackbot.Data.Services
{
    using System;
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Domain.Model;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using Slack.Common;
    using Slack.Common.LayoutBlocks;

    public static class SlackResponseHelper
    {
        public static ISlackResponseMessage BuildHelpResponse()
        {
            return new SlackResponseMessage
            {
                Payload = new MessagePayload
                {
                    Blocks = new List<Section>
                    {
                        new Section
                        {

                        }
                    }
                }
            };
        }

        internal static ISlackResponseMessage BuildKudoCreatedResponse(Kudo kudo)
        {
            throw new NotImplementedException();
        }

        internal static ISlackResponseMessage BuildKudoDeletedResponse()
        {
            throw new NotImplementedException();
        }

        internal static ISlackResponseMessage BuildKudoReplacedResponse(Kudo kudo)
        {
            throw new NotImplementedException();
        }

        internal static ISlackResponseMessage BuildNotEvenASingleKudoResponse()
        {
            throw new NotImplementedException();
        }

        internal static ISlackResponseMessage BuildListKudosResponse(IEnumerable<Kudo> kudos)
        {
            throw new NotImplementedException();
        }

        internal static ISlackResponseMessage BuildNotASingleKudoGivenResponse()
        {
            throw new NotImplementedException();
        }

        internal static ISlackResponseMessage BuildSlashResponseFromKudoList(IEnumerable<Kudo> kudos)
        {
            throw new NotImplementedException();
        }

        internal static ISlackResponseMessage BuildDummyResponse()
        {
            throw new NotImplementedException();
        }
    }
}