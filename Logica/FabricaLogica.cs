using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaCompañia GetLogicaCompañia()
        {
            return (LogicaCompañia.GetInstance());
        }
        public static ILogicaEmpleado GetLogicaEmpleado()
        {
            return (LogicaEmpleado.GetInstance());
        }
        public static ILogicaTerminal GetLogicaTerminal()
        {
            return (LogicaTerminal.GetInstance());
        }
        public static ILogicaViaje GetLogicaViaje()
        {
            return (LogicaViaje.GetInstance());
        }
    }
}
