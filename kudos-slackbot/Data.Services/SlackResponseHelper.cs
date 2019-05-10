namespace KudosSlackbot.Data.Services
{
    using System;
    using System.Collections.Generic;

    using KudosSlackbot.Domain.Model;

    using Slack.Common;

    public static class SlackResponseHelper
    {
        public static ISlackResponseMessage BuildHelpResponse()
        {
            return
                new AttachmentsPayload
                {
                    Text = @"
*   Create a kudu: `/kudo add <slack-id> <text>` where:

    -   `<slack-id>` defines the individual receiving the recognition
    -   `<text>` is your kudo for that person

*   Modify a kudu: `/kudo replace <kudo-id> <text>` where:

    -   `<action>` is 'replace' or 'delete'
    -   `<kudo-id>` is the kudo identifier
    -   `<text>` is your kudo for that person

*   Delete a kudu: `/kudo delete <kudo-id>`

*   Display the most recent _n_ kudos: `/kudo list <n>` where `n` is an integer or `*` for all kudos

*   Display all kudos for an individual with: `/kudo user <slack-id>`

*   List users with most kudos: `/kudo top <n>` where n is an integer or * for all individuals who have received a kudo"
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