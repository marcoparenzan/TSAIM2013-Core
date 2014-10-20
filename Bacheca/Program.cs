using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacheca
{
    class Program
    {
        public static LaBacheca _bacheca;

        static void MessaggioPubblicato(object sender, string e)
        {
            Console.WriteLine("[2] {0}", e);
        }

        static void Main(string[] args)
        {
            var messaggio = new
            {
                Testo = "blablabla"
                , Oggetto = "blablabla"
            };

            _bacheca = new LaBacheca();

            //...
            _bacheca.MessagePublished = (s, e) =>
            {
                Console.WriteLine("[1] {0}", e);
            };

            _bacheca.MessagePublished = MessaggioPubblicato;

            // ...

            _bacheca.NewMessage("Primo messaggio");

            Console.ReadLine();
        }
    }
}
