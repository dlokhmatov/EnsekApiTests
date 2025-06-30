using System.Text.Json;

namespace EnsekApiTests.Utilities
{
    public static class JsonHelper
    {
        public static T DeserializeResponse<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("The JSON content cannot be null or empty", nameof(json));
            }

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            })!;
        }
    }
}
