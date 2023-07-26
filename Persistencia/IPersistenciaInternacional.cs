
using Entidades_Compartidas;

namespace Persistencia
{
    public interface IPersistenciaInternacional
    {
        Internacional BuscarTAI(string TIActiva);
        void Alta(Internacional unaTi);
        void Modificar(Internacional unaTi);
        void Baja(Internacional unaTi);
    }
}
