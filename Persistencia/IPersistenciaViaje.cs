using System.Collections.Generic;

using Entidades_Compartidas;

namespace Persistencia
{
    public interface IPersistenciaViaje
    {
        void AltaViaje(Viaje UnV);
        List<Viaje> ListadoViajes();
        List<Viaje> ListadoViajesAM();
    }
}
