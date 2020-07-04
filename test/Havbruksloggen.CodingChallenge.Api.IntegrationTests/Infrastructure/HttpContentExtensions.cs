using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Havbruksloggen.CodingChallenge.Api.IntegrationTests.Infrastructure
{
    internal static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }

        public static HttpContent ToStringContent(this object source)
        {
            string json = source.ToJson();
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source, new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}
