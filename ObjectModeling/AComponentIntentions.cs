using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModeling
{
    public static class AComponentIntentions
    {
        public static void Usage()
        {
            var component = new AComponent
            {
                Property = 5
            };
            component.ApplyHappened += (o, a) => {

                Console.WriteLine("{0} happened", a);
            }; 
        }
    }
}
