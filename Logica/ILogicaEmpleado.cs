using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;

namespace Logica
{
    public interface ILogicaEmpleado
    {
        Empleado Logueo(string pUsu, string pPass);
        Empleado Buscar(string unE);
        void Alta(Empleado unE);
    }
}
