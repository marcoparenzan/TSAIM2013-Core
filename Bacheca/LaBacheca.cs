using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacheca
{
    public class LaBacheca
    {
        public void NewMessage(string message)
        {
            // some logic

            if (MessagePublished != null)
            {
                MessagePublished(this, message);
            }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }



        public DateTime Oggi { get; set; }

        public EventHandler<string> MessagePublished;
    }
}
