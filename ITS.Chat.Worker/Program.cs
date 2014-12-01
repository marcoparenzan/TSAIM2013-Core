using ITS.Chat.Models.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Chat.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var evt = new TalkEvent{
                Sender = "me"
                ,
                Timestamp = DateTime.UtcNow
                ,
                TalkId = "123"
            };
            var evtJson = JsonConvert.SerializeObject(evt);
            var evtByteArray = Encoding.UTF8.GetBytes(evtJson);
            var byteArray = new ByteArrayContent(evtByteArray);
            byteArray.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            HttpClient client = new HttpClient();
            var task = client.PostAsync("http://localhost:4839/worker/talk", byteArray);
            task.Wait();
        }
    }
}
