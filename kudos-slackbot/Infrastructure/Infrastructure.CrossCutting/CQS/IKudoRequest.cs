namespace KudosSlackbot.Infrastructure.CrossCutting.CQS
{

    using MediatR;

    using Slack.Common;

    public interface IKudoRequest : IRequest<ISlackResponseMessage>
    {
    }
}
