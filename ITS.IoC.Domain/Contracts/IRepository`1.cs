using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.IoC.Domain.Contracts
{
    public interface IRepository<T>
    {
        T GetById(string id);
    }
}
