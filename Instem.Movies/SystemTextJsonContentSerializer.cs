using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Refit;

namespace Instem.Movies
{
    public sealed class SystemTextJsonContentSerializer : IContentSerializer
    {
        private static readonly MediaTypeHeaderValue JsonMediaType =
            new MediaTypeHeaderValue("application/json") { CharSet = Encoding.UTF8.WebName };

        public SystemTextJsonContentSerializer(JsonSerializerOptions serializerOptions)
        {
            SerializerOptions = serializerOptions;
        }

        private JsonSerializerOptions SerializerOptions { get; }

        public async Task<T> DeserializeAsync<T>(HttpContent content)
        {
            await using var utf8Json = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(utf8Json, SerializerOptions);
        }

        public async Task<HttpContent> SerializeAsync<T>(T item)
        {
            var stream = new MemoryStream();

            try
            {
                await JsonSerializer.SerializeAsync(stream, item, SerializerOptions);
                await stream.FlushAsync();

                var content = new StreamContent(stream);

                content.Headers.ContentType = JsonMediaType;

                return content;
            }
            catch (Exception)
            {
                await stream.DisposeAsync();
                throw;
            }
        }
    }
}
