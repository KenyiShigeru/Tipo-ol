using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiador
{
    internal class ErrorPuntoyComa:Exception
    {
        public ErrorPuntoyComa() : base("Se esperaba un punto y coma")
        {

        }
    }
}
