namespace KudosSlackbot.Infrastructure.CrossCutting.CQS
{
    using System.Collections.Generic;

    using MediatR;

    using Slack.Common.LayoutBlocks;

    public interface IKudoRequest : IRequest<IEnumerable<LayoutBlock>>
    {
    }
}
