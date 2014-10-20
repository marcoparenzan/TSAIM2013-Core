using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public static class ExceptionIntentions
    {
        public static void NotFound<T>(T value)
        {
            if (object.ReferenceEquals(value, default(T)))
            {
                TracingIntentions.Log();
                throw new IndexOutOfRangeException();
            }
        }
    }
}
