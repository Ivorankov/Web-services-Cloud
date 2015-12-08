namespace Problem_04.StringsClient
{
    using System;

    internal class Startup
    {
        static void Main()
        {
            var client = new ServiceReference1.StringSearcherServiceClient();

            var result = client.GetCount("asdasdasd", "asd");

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
