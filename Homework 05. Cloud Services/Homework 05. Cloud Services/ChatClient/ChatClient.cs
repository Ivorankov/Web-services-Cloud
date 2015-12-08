using System.Threading;
using IronMqChatService;

namespace ChatClient
{
    public class ChatClient
    {
        private string userName;

        private Thread receivingThread;

        private delegate void AddMessage(string message);

        private delegate void AwaitServerResponse();

        private ChatService chatService;


    }
}
