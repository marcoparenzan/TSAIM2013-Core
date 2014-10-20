using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dichiarativi.SqlServer
{
    public class QuadroASqlServerRepository: IDisposable
    {
        private string _connectionStatus;

        public void Open()
        {
            _connectionStatus = "OPEN";
        }

        public void Close()
        {
            _connectionStatus = "CLOSE";
        }

        public QuadroA Get()
        {
            return null;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
