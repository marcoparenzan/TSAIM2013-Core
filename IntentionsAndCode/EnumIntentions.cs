using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public enum Currency
    {
        EUR
        ,
        USD
    }

    public static class EUROConverters
    {
        public static decimal ConvertTo(this decimal that, Currency testc)
        {
            switch (testc)
            {
                case Currency.EUR:
                    return that;
                case Currency.USD:
                    return that*1.2M;
                default:
                    throw new NotSupportedException("Currency not supported");
            }
        }
    }
}
