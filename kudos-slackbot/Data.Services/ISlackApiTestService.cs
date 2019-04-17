namespace KudosSlackbot.Data.Services
{
    using System.Threading.Tasks;

    public interface ISlackApiTestService
    {
        Task<object> TestSlackApi();
    }
}
