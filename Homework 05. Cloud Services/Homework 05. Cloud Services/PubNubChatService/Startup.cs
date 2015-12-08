namespace PubNubChatService
{
    using System;
    using PubNubMessaging.Core;

    internal class Startup
    {
        private static Pubnub client;

        static void Main()
        {
            client = new Pubnub(
                "pub-c-09178b0a-01a8-46f0-84f7-5311ce53182b ",
                "sub-c-7cb1033e-8c77-11e5-9320-02ee2ddab7fe",
                "sec-c-MThlNzU2OTMtOGFhMS00OTg4LWIzOTQtNzFkZjUzMjgyZmFi ");

            client.Subscribe<string>(
                                "App",
                                DisplaySubscribeReturnMessage,
                                DisplaySubscribeConnectStatusMessage,
                                DisplayErrorMessage);
         }

        static void DisplaySubscribeConnectStatusMessage(string connectMessage)
        {
            Console.WriteLine("SUBSCRIBE CONNECT CALLBACK");
            client.Publish<string>(
                "App",
                "Hello from the PubNub C# SDK",
                DisplayReturnMessage,
                DisplayErrorMessage);
        }

        static void DisplaySubscribeReturnMessage(string result)
        {
            Console.WriteLine("SUBSCRIBE REGULAR CALLBACK:");
            Console.WriteLine(result);
        }

        static void DisplayErrorMessage(PubnubClientError pubnubError)
        {
            Console.WriteLine(pubnubError.StatusCode);
        }

        static void DisplayReturnMessage(string result)
        {
            Console.WriteLine("PUBLISH STATUS CALLBACK");
            Console.WriteLine(result);
        }
    }
}
