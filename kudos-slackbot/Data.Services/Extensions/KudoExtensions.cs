namespace KudosSlackbot.Data.Services.Extensions
{
    using System.Linq;

    using KudosSlackbot.Domain.Model;

    public static class KudoExtensions
    {
        public static string GetAddKudoMessage(this Kudo kudo)
        {
            var commandText = kudo.CommandText;

            var textList = commandText.Split(' ').ToList();

            textList.RemoveRange(0, 2);

            var delimiter = " ";

            return textList.Aggregate((i, j) => i + delimiter + j);
        }
    }
}
