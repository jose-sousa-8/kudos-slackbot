namespace KudosSlackbot.Data.Services.Extensions
{
    using System.Linq;

    using KudosSlackbot.Domain.Model;

    public static class KudoExtensions
    {
        /// <summary>
        /// Gets the kudo command message by removing the first n words from the message.
        /// </summary>
        /// <param name="kudo">The kudo object</param>
        /// <param name="n">The number of word to remove from left to right</param>
        /// <returns></returns>
        public static string GetKudoMessage(this Kudo kudo, int n)
        {
            var commandText = kudo.CommandText;

            var textList = commandText.Split(' ').ToList();

            textList.RemoveRange(0, n);

            var delimiter = " ";

            return textList.Aggregate((i, j) => i + delimiter + j);
        }
    }
}
