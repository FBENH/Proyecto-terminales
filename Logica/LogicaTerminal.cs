using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    internal class LogicaTerminal: ILogicaTerminal
    {
        //singleton
        private static LogicaTerminal _instancia = null;
        private LogicaTerminal() { }
        public static LogicaTerminal GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaTerminal();

            return _instancia;
        }//fin singleton
        public Terminal BuscarTA(string TActiva)
        {
            Terminal _unaTer = null;
            _unaTer = FabricaPersistencia.GetPersistenciaInternacional().BuscarTAI(TActiva);
            if (_unaTer == null)
                _unaTer = FabricaPersistencia.GetPersistenciaNacional().BuscarTAN(TActiva);
            return _unaTer;
        }
        public void Alta(Terminal unaTer)
        {
            if (unaTer is Internacional)
                FabricaPersistencia.GetPersistenciaInternacional().Alta((Internacional)unaTer);
            else
                FabricaPersistencia.GetPersistenciaNacional().Alta((Nacional)unaTer);
        }
        public void Modificar(Terminal unaTer)
        {
            if (unaTer is Internacional)
                FabricaPersistencia.GetPersistenciaInternacional().Modificar((Internacional)unaTer);
            else
                FabricaPersistencia.GetPersistenciaNacional().Modificar((Nacional)unaTer);
        }
        public void Baja(Terminal unaTer)
        {
            if (unaTer is Internacional)
                FabricaPersistencia.GetPersistenciaInternacional().Baja((Internacional)unaTer);
            else
                FabricaPersistencia.GetPersistenciaNacional().Baja((Nacional)unaTer);
        }
    }
}
