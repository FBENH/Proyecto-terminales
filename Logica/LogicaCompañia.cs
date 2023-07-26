using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    internal class LogicaCompañia : ILogicaCompañia
    {
        //singleton
        private static LogicaCompañia _instancia = null;
        private LogicaCompañia() { }
        public static LogicaCompañia GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaCompañia();

            return _instancia;
        }//fin singleton
        public Compañia Buscar(string unaC)
        {
            IPersistenciaCompañia FCompañia = FabricaPersistencia.GetPersistenciaCompañia();
            return FCompañia.Buscar(unaC);
        }
        public void Alta(Compañia unaC)
        {
            IPersistenciaCompañia FCompañia = FabricaPersistencia.GetPersistenciaCompañia();
            FCompañia.Alta(unaC);
        }
    }
}
