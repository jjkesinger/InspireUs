using System;
using System.ComponentModel;
using System.Reflection;

namespace InspireUs.Congress.Shared
{
	public static class EnumExtensions
	{
		public static T? GetValueFromDescription<T>(string description) where T: Enum
		{
			foreach( var field in typeof(T).GetFields())
			{
				if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
				{
					if (attribute.Description == description)
					{
						return (T?)field.GetValue(null);
					}
					else
					{
						if (field.Name == description)
						{
							return (T?)field.GetValue(null);
						}
					}
				}
			}

            throw new ArgumentException("Description not found.", nameof(description));
        }

        public static string GetDescription<T>(this T source)
        {
#pragma warning disable CS8602
#pragma warning disable CS8604
#pragma warning disable CS8600
#pragma warning disable CS8603
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
#pragma warning restore CS8600
#pragma warning restore CS8604
#pragma warning restore CS8602
#pragma warning restore CS8603
        }
    }
}

