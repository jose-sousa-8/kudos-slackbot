namespace KudosSlackbot.Data.Repository
{
    using System;

    using KudosSlackbot.Infrastructure.CrossCutting.Adapters;

    public static class KudoMapper
    {
        private static Func<Domain.Model.Kudo, Data.Dbo.Kudo> mapFunction = (source) =>
        {
            return new Dbo.Kudo
            {
                ByUserId = source.ByUserId,
                ByUsername = source.ByUsername,
                ChannelId = source.ChannelId,
                ChannelName = source.ChannelName,
                UserId = source.UserId,
                Username = source.Username,
                Text = source.Text
            };
        };

        public static Data.Dbo.Kudo Map<T>(this Domain.Model.Kudo source) where T : Data.Dbo.Kudo
        {
            return Mapper.Map(source, mapFunction);
        }
    }
}
