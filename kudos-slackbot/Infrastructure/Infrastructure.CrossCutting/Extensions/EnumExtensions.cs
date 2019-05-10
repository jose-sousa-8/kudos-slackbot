namespace KudosSlackbot.Infrastructure.CrossCutting.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
