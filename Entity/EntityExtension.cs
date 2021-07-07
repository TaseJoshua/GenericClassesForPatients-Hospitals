using System.Text.Json;

namespace GenericClassesForPatients.Entity
{
    public static class EntityExtension
    {
        public static T? CopyTo<T>(this T itemToCopy)
        {
            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
