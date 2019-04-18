namespace KudosSlackbot.Infrastructure.CrossCutting.Adapters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Mapper
    {
        public static IEnumerable<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> source, Func<TSource, TTarget> mapFunction)
            where TSource : class
            where TTarget : class
        {
            if (source == null)
            {
                return null;
            }
            else if (!source.Any())
            {
                return new List<TTarget>();
            }

            return source.Select(x => Map(x, mapFunction)).ToList();
        }

        public static TTarget Map<TSource, TTarget>(TSource source, Func<TSource, TTarget> mapFunction)
            where TSource : class
            where TTarget : class
        {
            if (source == null)
            {
                return null;
            }

            return mapFunction(source);
        }

        public static TTarget Map<TFirstSource, TComplementarySource, TTarget>(TFirstSource firstSource, TComplementarySource secondSource, Func<TFirstSource, TComplementarySource, TTarget> mapFunction)
            where TFirstSource : class
            where TComplementarySource : class
            where TTarget : class
        {
            if (firstSource == null)
            {
                return null;
            }

            // The responsibility to check if the second source is null should
            // be in the mapping function since it should not be necessary to 
            // have an instance of the mapped object

            return mapFunction(firstSource, secondSource);
        }

        public static IDictionary<TTargetKey, TTargetValue> Map<TSourceKey, TTargetKey, TSourceValue, TTargetValue>(
            IDictionary<TSourceKey, TSourceValue> dictionary,
            Func<TSourceKey, TTargetKey> mapKeyFunction,
            Func<TSourceValue, TTargetValue> mapValueFunction)
            where TSourceValue : class
            where TTargetValue : class
        {
            return dictionary?.ToDictionary(entry => mapKeyFunction(entry.Key), entry => mapValueFunction(entry.Value));
        }
    }
}
