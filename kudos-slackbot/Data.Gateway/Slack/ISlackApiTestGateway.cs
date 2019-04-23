namespace KudosSlackbot.Data.Gateway.Slack
{
    using System.Threading.Tasks;

    public interface ISlackApiTestGateway
    {
        Task<object> TestSlackApi();
    }
}