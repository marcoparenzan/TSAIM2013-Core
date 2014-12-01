using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Chat.Models.WorkerCommands
{
    public class TalkToWorkerCommand
    {
        public string CommandType { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
