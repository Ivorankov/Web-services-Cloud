using System;
using System.Threading;

namespace IronMqChatService
{
    public class ChatClient
    {
        private Thread receivingThread;

        private delegate void AddMessage(string message);

        private ChatService chatService;

        public ChatClient()
        {
            this.chatService = new ChatService();
            InitializeReceiver();
        }

        public void SendMessageData(string userIp, string msg)
        {
            if (msg.Length != 0)
            {
                var messageData = userIp + ": " + msg;
                this.chatService.Send(messageData);
            }
        }

        private void InitializeReceiver()
        {
            ThreadStart start = new ThreadStart(Receiver);
            receivingThread = new Thread(start);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }

        private void Receiver()
        {
            AddMessage messageDelegate = MessageReceived;

            while (true)
            {
                var msg = this.chatService.Receve();
                if (msg != null)
                {
                    messageDelegate.Invoke(msg.Body);
                }

            }
        }
    }
}
