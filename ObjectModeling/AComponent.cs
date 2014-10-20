using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModeling
{
    public class AComponent
    {
        private int _backingVariable;

        public int Property
        {
            get { return _backingVariable; }
            set { _backingVariable = value; }
        }

        public int CalculatedProperty
        {
            get { return _backingVariable+1; }
        }

        public int Method(int anArg)
        {
            return anArg + CalculatedProperty + Property;
        }

        public void Apply(int anArg)
        {
            this._backingVariable += anArg;
            if (ApplyHappened != null) ApplyHappened(this, this._backingVariable);  
        }

        public event EventHandler<int> ApplyHappened;
    }
}
