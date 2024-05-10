using System.Reflection;

namespace TestUtilities.Helpers
{
    public static class FieldHelper
    {
        public static object GetPrivateFieldValue(object instance, string fieldName)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var type = instance.GetType();
            var field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (field == null)
                throw new ArgumentException($"Field '{fieldName}' not found in type '{type.FullName}'.");

            return field.GetValue(instance);
        }
    }
}
