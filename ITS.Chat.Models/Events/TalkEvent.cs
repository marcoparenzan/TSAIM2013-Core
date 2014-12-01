using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Chat.Models.Events
{
    public class TalkEvent
    {
        public string TalkId { get; set; }
        public string Sender { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
