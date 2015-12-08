namespace IronMqChatService
{
    using System;
    using System.Net;

    internal class Startup
    {
        //This is the solution for the fist two tasks

        static void Main()
        {
            var a = new ChatClient();
            var isConnected = true;
            Console.WriteLine(@"Write 'exit' to quit");
            var ipAddress = Dns.GetHostEntry("localhost").AddressList[1];
            IPEndPoint endPoint = new IPEndPoint(ipAddress, 9111);
            var userIp = endPoint.Address;
            while (isConnected)
            {
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "exit")
                {
                    break;
                }
                else if (userInput.Length == 0)
                {
                    continue;
                }
                else
                {
                    a.SendMessageData(userIp.ToString(), userInput);
                }
            }
        }
    }
}
