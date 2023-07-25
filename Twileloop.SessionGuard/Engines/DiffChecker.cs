using System;
using System.Collections.Generic;
using System.Reflection;

namespace Twileloop.SessionGuard.Engines
{
    public static class DiffChecker<T>
    {
        public static List<string> GetChangedProperties(T a, T b)
        {
            List<string> changedProperties = new List<string>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object valueA = property.GetValue(a);
                object valueB = property.GetValue(b);

                if (!Equals(valueA, valueB))
                {
                    if (IsSimpleType(property.PropertyType))
                    {
                        changedProperties.Add(property.Name);
                    }
                    else
                    {
                        List<string> nestedChanges = GetChangedProperties((T)valueA, (T)valueB);
                        foreach (string nestedProperty in nestedChanges)
                        {
                            string propertyName = property.Name + "." + nestedProperty;
                            changedProperties.Add(propertyName);
                        }
                    }
                }
            }

            return changedProperties;
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive || type.IsValueType || type == typeof(string);
        }
    }

}
