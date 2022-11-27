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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            FieldInfo fi = source.GetType().GetField(source.ToString());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

#pragma warning disable CS8603 // Possible null reference return.
            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}

