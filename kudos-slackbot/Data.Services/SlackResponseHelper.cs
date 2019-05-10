namespace KudosSlackbot.Data.Services
{
    using System;
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Domain.Model;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using Slack.Common;
    using Slack.Common.LayoutBlocks;
    using Slack.Common.LayoutBlocks.CompositionObjects;

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
                            Text = new TextObject
                            {
                                Type = "mrkdwn",
                                Text = @"
-   Create a kudu: `/kudo add <slack-id> <text>` where:

    -   `<slack-id>` defines the individual receiving the recognition
    -   `<text>` is your kudo for that person

-   Modify a kudu: `/kudo replace <kudo-id> <text>` where:

    -   `<action>` is 'replace' or 'delete'
    -   `<kudo-id>` is the kudo identifier
    -   `<text>` is your kudo for that person

-   Delete a kudu: `/kudo delete <kudo-id>`

-   Display the most recent _n_ kudos: `/kudo list <n>` where `n` is an integer or `*` for all kudos

-   Display all kudos for an individual with: `/kudo user <slack-id>`

-   List the individual having the most kudos, in descending order, user the Slack command: /kudo top <n> where n is an integer or * for all individuals who have received a kudo"
                            }
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