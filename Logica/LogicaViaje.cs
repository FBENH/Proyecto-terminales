using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaViaje : ILogicaViaje
    {
        //singleton
        private static LogicaViaje _instancia = null;
        private LogicaViaje() { }
        public static LogicaViaje GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaViaje();// creo un objeto de si mismo

            return _instancia;
        }//fin singleton

        public void AltaViaje(Viaje UnV)
        {
            if (UnV.FechaHoraD > DateTime.Now)
            {
                IPersistenciaViaje FViaje = FabricaPersistencia.GetPersistenciaViaje();
                FViaje.AltaViaje(UnV);
            }
            else
                throw new Exception("La fecha de salida debe ser a futuro.");
            
        }
        public List<Viaje> ListadoViajes()
        {
            IPersistenciaViaje FViaje = FabricaPersistencia.GetPersistenciaViaje();
            return FViaje.ListadoViajes();
        }
        public List<Viaje> ListadoViajesAM()
        {
            IPersistenciaViaje FViaje = FabricaPersistencia.GetPersistenciaViaje();
            return FViaje.ListadoViajesAM();
        }
    }
}
