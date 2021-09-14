using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var url = "http://jsonplaceholder.typicode.com/posts";
            await ProcessUrl(url, id: 1);
        }

        private static async Task ProcessUrl(string url, int id)
        {
            id--;
            var httpResponse = await client.GetAsync(url);
            var status = httpResponse.StatusCode;
            var content = await httpResponse.Content.ReadAsStringAsync();
            var post = JsonSerializer.Deserialize<List<Post>>(content);
            var msg = $"Status: {status}\n\n" +
                $"Content:\n" +
                $"UserId: {post[id].UserId}\n" +
                $"Id: {post[id].Id}\n" +
                $"Title: {post[id].Title}\n" +
                $"Body {post[id].Body}\n\n" +
                $"Body Length: {post[id].Body.Length} characters";

            Console.WriteLine(msg);
        }
    }
}
