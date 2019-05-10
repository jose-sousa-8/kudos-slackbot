namespace KudosSlackbot.Infrastructure.CrossCutting.CQS
{
    using MediatR;

    public interface IKudoRequest : IRequest<ISlackResponseMessage>
    {
    }
}
