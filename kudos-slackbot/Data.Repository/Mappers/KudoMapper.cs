namespace KudosSlackbot.Data.Repository
{
    using System;
    using System.Collections.Generic;

    using KudosSlackbot.Infrastructure.CrossCutting.Adapters;

    public static class KudoMapper
    {
        private static Func<Domain.Model.Kudo, Data.Dbo.Kudo> mapModelToDboFunction = (source) =>
        {
            return new Dbo.Kudo
            {
                ByUserId = source.ByUserId,
                ByUsername = source.ByUsername,
                ChannelId = source.ChannelId,
                ChannelName = source.ChannelName,
                UserId = source.UserId,
                Username = source.Username,
                Text = source.Text,
                CommandText = source.CommandText
            };
        };

        private static Func<Data.Dbo.Kudo, Domain.Model.Kudo> mapDboToModelFunction = (source) =>
        {
            return new Domain.Model.Kudo
            {
                ByUserId = source.ByUserId,
                ByUsername = source.ByUsername,
                ChannelId = source.ChannelId,
                ChannelName = source.ChannelName,
                UserId = source.UserId,
                Username = source.Username,
                Text = source.Text,
                CommandText = source.CommandText
            };
        };

        public static Data.Dbo.Kudo Map<T>(this Domain.Model.Kudo source) where T : Data.Dbo.Kudo
        {
            return Mapper.Map(source, mapModelToDboFunction);
        }

        public static Domain.Model.Kudo Map<T>(this Data.Dbo.Kudo source) where T : Domain.Model.Kudo
        {
            return Mapper.Map(source, mapDboToModelFunction);
        }

        public static IEnumerable<Domain.Model.Kudo> Map<T>(this IEnumerable<Data.Dbo.Kudo> source) where T : IEnumerable<Domain.Model.Kudo>
        {
            return Mapper.Map(source, mapDboToModelFunction);
        }
    }
}
