namespace IronMqChatService
{
    using System;
    using System.Collections.Generic;
    using IronSharp.Core;
    using IronSharp.IronMQ;

    public class ChatService
    {
        private IronMqRestClient ironMq;

        private QueueClient currentQueue;

        private List<string> msgCache = new List<string>();

        public ChatService()
        {
            this.ironMq = Client.New(
                new IronClientConfig
                {
                    ProjectId = "56420b6f9195a800080000b6",
                    Token = "ANgrGMpOtkzSxbTIlWbk",
                    Host = "mq-aws-eu-west-1-1.iron.io",
                    ApiVersion = 3
                });

            this.currentQueue = this.ironMq.Queue("Global");
        }

        public void Send(string message)
        {
            this.currentQueue.Post(message);
        }

        public QueueMessage Receve()
        {
            var msg = this.currentQueue.Next(new TimeSpan(0, 0, 30));
            if (msg != null)
            {
                if (!this.msgCache.Contains(msg.Id))
                {
                    msgCache.Add(msg.Id);
                    return msg;
                }

                return null;

            }
            else
            {
                return null;
            }
        }
    }
}

