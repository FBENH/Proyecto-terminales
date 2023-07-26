using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    public interface ILogicaViaje
    {
        void AltaViaje(Viaje UnV);
        List<Viaje> ListadoViajes();
        List<Viaje> ListadoViajesAM();
    }
}
