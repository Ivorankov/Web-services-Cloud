namespace NewsFeedRequests
{
    using System;
    using Newtonsoft.Json.Linq;
    using System.Net.Http;

    public class Startup
    {
        static void Main()
        {
            var client = new HttpClient();
            Console.WriteLine("Write some search param");
            var searchParam = Console.ReadLine();
            var address = string.Format(
                "https://www.googleapis.com/books/v1/volumes?q={0}+inauthor:",
                searchParam);

            var response = client.GetStringAsync(address);
            var jsonRes = JObject.Parse(response.Result);
            foreach (var item in jsonRes["items"])
            {
                var bookInfo = item.SelectToken("volumeInfo").First; //Title of the book, no need to spam the console too much 
                Console.WriteLine(bookInfo);
            }

            Console.ReadKey();
        }
    }
}
