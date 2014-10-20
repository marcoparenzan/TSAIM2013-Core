using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public struct EURO
    {
        private decimal _value;

        public static implicit operator decimal(EURO currency)
        {
            return currency._value;
        }

        public static implicit operator EURO(decimal value)
        {
            return new EURO { 
                _value = value
            };
        }

        public static implicit operator EURO(double value)
        {
            return new EURO
            {
                _value = (decimal) value
            };
        }

        public static implicit operator EURO(int value)
        {
            return new EURO
            {
                _value = (decimal)value
            };
        }

        public EURO IVA(decimal percentualeIva)
        {
            return _value * (percentualeIva);
        }

        public EURO ConIVA(decimal percentualeIva)
        {
            return _value * (1 + percentualeIva);
        }

        public EURO ConRitenuta(decimal percentualeRitenuta)
        {
            return _value * (1 + percentualeRitenuta);
        }
    }

    public static class CurrencyExtension
    {
        public static EURO Currency(this decimal that)
        {
            return that;
        }

        public static EURO Currency(this double that)
        {
            return that;
        }

        public static EURO Currency(this int that)
        {
            return that;
        }
    }
}
