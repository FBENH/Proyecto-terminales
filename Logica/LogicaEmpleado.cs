using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    internal class LogicaEmpleado : ILogicaEmpleado
    {

        //singleton
        private static LogicaEmpleado _instancia = null;
        private LogicaEmpleado() { }
        public static LogicaEmpleado GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaEmpleado();
            return _instancia;
        }//fin singleton
        public Empleado Logueo(string pUsu, string pPass)
        {
            IPersistenciaEmpleado FEmpleado= FabricaPersistencia.GetPersistenciaEmpleado();
            return FEmpleado.Logueo(pUsu, pPass);
        }
        public Empleado Buscar(string unE)
        {
            IPersistenciaEmpleado FEmpleado = FabricaPersistencia.GetPersistenciaEmpleado();
            return FEmpleado.Buscar(unE);
        }
        public void Alta(Empleado unE)
        {
            IPersistenciaEmpleado FEmpleado = FabricaPersistencia.GetPersistenciaEmpleado();
            FEmpleado.Alta(unE);
        }
    }
}
