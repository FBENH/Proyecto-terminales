
using Entidades_Compartidas;
namespace Persistencia
{
    public interface IPersistenciaEmpleado
    {
        Empleado Logueo(string pUsu, string pPass);
        Empleado Buscar(string unE);
        void Alta(Empleado unE);
    }
}
