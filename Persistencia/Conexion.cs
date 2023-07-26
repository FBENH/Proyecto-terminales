namespace Persistencia
{
    internal class Conexion
    {
        private static string _con = "Data Source=.; Initial Catalog = Proyecto_Diseño_I; Integrated Security = true";

        public static string Cnn
        {
            get { return _con; }
        }
    }
}
