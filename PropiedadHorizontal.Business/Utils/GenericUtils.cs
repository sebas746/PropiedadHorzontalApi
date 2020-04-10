using System;
using System.Reflection;

namespace PropiedadHorizontal.Business.Utils
{
    public static class GenericUtils<T>
    {
        // <summary>
        /// Checks if the given property name exists
        /// to protect against SQL injection attacks
        /// </summary>
        public static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(T).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Instance);
            if (prop == null && throwExceptionIfNotFound)
                throw new NotSupportedException(String.Format("ERROR: Property '{0}' does not exist.", propertyName));
            return prop != null;
        }
    }
}
