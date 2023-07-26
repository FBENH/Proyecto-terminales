
using Entidades_Compartidas;

namespace Persistencia
{
    public interface IPersistenciaCompañia
    {
        Compañia Buscar(string unaC);
        void Alta(Compañia unaC);
    }
}
