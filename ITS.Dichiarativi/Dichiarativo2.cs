using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    internal class Dichiarativo2: IDichiarativo
    {
        private int _id;

        internal Dichiarativo2(int id)
        {
            _id = id;
            _quadri = new List<IQuadro>();
        }

        //public static IDichiarativo ById(int id)
        //{
        //    if (true)
        //    {
        //        /// cerca in un repository
        //        return null;
        //    }
        //    else
        //    {
        //        return new Dichiarativo2();
        //    }
        //}

        //public static IDichiarativo CreateNew()
        //{
        //    return new Dichiarativo2();
        //}

        private List<IQuadro> _quadri;
        private decimal _totale;

        //public Dichiarativo2()
        //{
        //    _quadri = new List<IQuadro>();
        //    //_quadri.Add(new QuadroA());
        //    //_quadri.Add(new QuadroB());
        //    //_quadri.Add(new QuadroC());
        //}

        int IDichiarativo.Id {
            get {

                return _id;
            }
        
        }

        T IDichiarativo.Get<T>()
        {
            var q = _quadri.SingleOrDefault(xx => xx is T);
            if (q != null)
            {
                return (T)q;
            }
            else
            {
                q = (IQuadro)Activator.CreateInstance<T>();
                _quadri.Add(q);
                return (T)q;
            }
            throw new ArgumentException("T not found");
        }

        void IRicalcolo.Calcola()
        {
            //_totale = 0.0M;
            //foreach (var quadro in _quadri)
            //{
            //    _totale += quadro.Totale;
            //}
            // _totale = _quadri.Sum(xx => xx.Totale);
            //foreach (dynamic q in _quadri)
            //{
            //    _totale += (decimal)q.Pippo ;
            //}
            foreach (var q in _quadri)
            {
                var pi = q.GetType().GetProperty("Totale");
                _totale += (decimal) pi.GetValue(q, null);
            }
        }

        decimal IRicalcolo.Totale
        {
            get { return _totale; }
        }
    }
}
