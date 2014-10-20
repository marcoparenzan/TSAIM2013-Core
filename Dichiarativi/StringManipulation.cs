using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dichiarativi
{
    public static class StringManipulation
    {
        public static string MaxLength(
            this string that
            , int length = 64
        )
        {
            if (that.Length <= length)
            {
                return that;
            }
            else
            {
                return that.Substring(0, length);
            }
        }

        private static Regex _codiceFiscaleRegex = 
            new Regex(
                "^[A-Z]{3}[A-Z]{3}[0-9]{2}[A-Z]{1}[0-9]{2}[A-Z]{1}[0-9]{3}[A-Z]{1}$");

        public static void IsCodiceFiscale(this string that)
        {
            if (!_codiceFiscaleRegex.Match(that).Success)
                throw new ArgumentException("String is not a CF");
        }
    }
}
