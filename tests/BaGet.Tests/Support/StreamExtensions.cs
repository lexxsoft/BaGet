using System.IO;
using Newtonsoft.Json;

namespace BaGet.Tests
{
    public static class StreamExtensions
    {
        public static string ToPrettifiedJson(this Stream jsonStream)
        {
            using var writer = new StringWriter(new System.Text.StringBuilder(), System.Globalization.CultureInfo.InvariantCulture)
            {
                NewLine = "\n",
            };
            using var jsonWriter = new JsonTextWriter(writer)
            {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using var reader = new StreamReader(jsonStream);
            using var jsonReader = new JsonTextReader(reader);

            jsonWriter.WriteToken(jsonReader);
            return writer.ToString();
        }
    }
}
