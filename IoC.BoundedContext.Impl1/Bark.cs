using Company.BoundedContext.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.BoundedContext.Impl1
{
    public class Bark: IDoSomething
    {
        void IDoSomething.DoSomething()
        {
            Console.WriteLine("Bark");
        }
    }
}
