using System.Linq;

namespace Dtx
{
	public static class Mapper
	{
		static Mapper()
		{
		}

		public static void Copy
			(object source, object target, string[] excludedProperties = null)
		{
			System.Type oSourceType = source.GetType();
			System.Type oTargetType = target.GetType();

			System.Reflection.PropertyInfo[] oSourceProperties =
				oSourceType.GetProperties();

			foreach (System.Reflection.PropertyInfo oSourcePropertyInfo in oSourceProperties)
			{
				// Filter the properties
				if ((excludedProperties != null) &&
					(excludedProperties.Contains(oSourcePropertyInfo.Name)))
				{
					continue;
				}

				System.Type oSourcePropertyInfoType = oSourcePropertyInfo.PropertyType;

				if (oSourcePropertyInfoType.IsArray)
				{
					continue;
				}

				string[] strValidTypes = { "System.String", "System.Guid", "System.DateTime" };

				if (strValidTypes.Contains(oSourcePropertyInfoType.FullName) == false)
				{
					//if (oSourcePropertyInfoType.IsPrimitive == false)
					//{
					//	continue;
					//}

					if (oSourcePropertyInfoType.IsValueType == false)
					{
						continue;
					}
				}

				// Get the matching property from the target
				System.Reflection.PropertyInfo oTargetPropertyInfo =
					oTargetType.GetProperty(oSourcePropertyInfo.Name);

				// If it exists and it's writeable
				if ((oTargetPropertyInfo != null) && (oTargetPropertyInfo.CanWrite))
				{
					// Copy the value from the source to the target
					object oSourceValue =
						oSourcePropertyInfo.GetValue(source, null);

					oTargetPropertyInfo.SetValue(target, oSourceValue, null);
				}
			}
		}
	}
}
