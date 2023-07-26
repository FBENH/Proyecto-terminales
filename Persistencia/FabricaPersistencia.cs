namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaCompañia GetPersistenciaCompañia()
        {
            return (PersistenciaCompañia.GetInstance());
        }
        public static IPersistenciaEmpleado GetPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.GetInstance());
        }
        public static IPersistenciaInternacional GetPersistenciaInternacional()
        {
            return (PersistenciaInternacional.GetInstance());
        }
        public static IPersistenciaNacional GetPersistenciaNacional()
        {
            return (PersistenciaNacional.GetInstance());
        }
        public static IPersistenciaViaje GetPersistenciaViaje()
        {
            return (PersistenciaViaje.GetInstance());
        }
    }
}
