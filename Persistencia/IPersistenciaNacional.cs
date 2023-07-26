
using Entidades_Compartidas;

namespace Persistencia
{
    public interface IPersistenciaNacional
    {
        Nacional BuscarTAN(string unaTN);
        void Alta(Nacional unaTN);
        void Modificar(Nacional unaTN);
        void Baja(Nacional unaTN);
    }
}
