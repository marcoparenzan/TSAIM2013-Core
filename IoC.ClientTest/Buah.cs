using Company.BoundedContext.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.ClientTest
{
    public class Buah: IDoSomethingElse
    {
        private IDoSomething _doSomething;

        public Buah(IDoSomething doSomething) {
            this._doSomething = doSomething;
        }
        void IDoSomethingElse.SomethingElse()
        {
            Console.WriteLine("Buah!");
            _doSomething.DoSomething();
        }
    }
}
