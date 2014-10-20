using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public static class WhileIntentions
    {
        public static bool Search<T>(this IEnumerable<T> that, T what)
        {
            var result = false;
            foreach (var item in that)
            {
                if (what.Equals(item))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> that, T what)
        {
            return that.Filter(what, (xx, yy) => xx.Equals(yy));
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> that, T what, Func<T, T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var item in that)
            {
                if (predicate(what, item))
                {
                    result.Add(item);
                    break;
                }
            }
            return result;
        }

        public static T1 Map<T, T1>(this T that, Func<T, T1> f)
        {
            return f(that);
        }

        public static T1 Reduce<T, T1>(this IEnumerable<T> that, Func<T1, T1, T1> step, Func<T, T1> select)
        {
            T1 accumulator = default(T1);
            foreach (var item in that)
            {
                accumulator = step(select(item), accumulator);
            }
            return accumulator;
        }

        public static T1 Reduce<T, T1>(this IEnumerable<T> that, Func<T, T1, T1> step)
        {
            T1 accumulator = default(T1);
            foreach (var item in that)
            {
                accumulator = step(item, accumulator);
            }
            return accumulator;
        }

        public static int Add<T>(this IEnumerable<T> that, Func<T, int> select)
        {
            return that.Reduce<T, int>((x, i) => select(x) + i);
        }
    }
}
