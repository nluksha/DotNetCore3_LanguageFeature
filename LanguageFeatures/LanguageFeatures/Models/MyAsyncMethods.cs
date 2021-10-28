using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        [Obsolete("This is obsolete. Use GetPageLength instead.", false)]
        public static Task<long?> GetPageLengthOld()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => antecedent.Result.Content.Headers.ContentLength);
        }

        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");

            return httpMessage.Content.Headers.ContentLength;
        }

        [Obsolete("This is obsolete. Use GetPageLengths instead.", false)]
        public static async Task<IEnumerable<long?>> GetPageLengthsOld(List<string> output, params string[] urls)
        {
            var results = new List<long?>();
            var client = new HttpClient();

            foreach (var url in urls)
            {
                output.Add($"Started request for {url}");

                var httpMessage = await client.GetAsync($"http://{url}");
                results.Add(httpMessage.Content.Headers.ContentLength);
                output.Add($"Completed request for {url}");
            }

            return results;
        }

        public static async IAsyncEnumerable<long?> GetPageLengths(List<string> output, params string[] urls)
        {
            var client = new HttpClient();

            foreach (var url in urls)
            {
                output.Add($"Started request for {url}");

                var httpMessage = await client.GetAsync($"http://{url}");
                output.Add($"Completed request for {url}");

                yield return httpMessage.Content.Headers.ContentLength;
            }
        }
    }
}
