using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public delegate T BinaryOperator<T>(T a, T b);
    public delegate T UnaryOperator<T>(T a);
    public delegate T1 Projector<T, T1>(T a);
    public delegate bool Predicate<T>(T a);
    public delegate IEnumerable<T> Selector<T>(IEnumerable<T> set);
    public delegate IEnumerable<T1> SelectorAndProjector<T, T1>(IEnumerable<T> set);
}