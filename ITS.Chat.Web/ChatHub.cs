using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ITS.Chat.Web
{
    public class ChatHub : Hub
    {
        public void Talk(string sender, DateTime timestamp, string talkId)
        {
            Clients.All.talk(sender, timestamp, talkId);
        }

        public void TalkTo(string sender, string recipient, DateTime timestamp, string talkId)
        {
            var recipientId = recipient;
            Clients.Client(recipientId).talk(sender, timestamp, talkId);
        }
    }
}