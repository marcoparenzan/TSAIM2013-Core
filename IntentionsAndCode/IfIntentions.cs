using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public static class IfIntentions
    {
        public static TResult Alternative<T, TResult>(this T that, Predicate<T> p, Func<T, TResult> ifTrue, Func<T, TResult> ifFalse)
        {
            if (p(that))
            {
                return ifTrue(that);
            }
            else
            {
                return ifFalse(that);
            }
        }

        public static TResult Lookup<TResult>(this int[] that, int arg, params Func<int,TResult>[] args)
        {
            TResult result = default(TResult);
            for (var i = 0; i < that.Length; i++) {
                if (arg <= that[i])
                {
                    result = args[i](arg);
                }
            }
            ExceptionIntentions.NotFound(result);
            return result;
        }


        private static void Assert(int arg)
        {
            if (arg < 0)
                throw new ArgumentException("Arg is below zero");
        }

        public static void Usage(int arg)
        {
            Assert(arg);
            Alternative(arg, x => x > 0, x => x + 1, x => -x - 1);
            (new int[] { 1, 7, 9 }).Lookup(arg, x => x + 1, x => x + 7, x => x + 9);
        }
    }
}
