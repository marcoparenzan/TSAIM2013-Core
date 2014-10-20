using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public struct Percentage
    {
        private decimal _value;

        public static implicit operator decimal(Percentage currency)
        {
            return currency._value;
        }

        public static implicit operator Percentage(decimal value)
        {
            return new Percentage
            {
                _value = value
            };
        }
    }
}
