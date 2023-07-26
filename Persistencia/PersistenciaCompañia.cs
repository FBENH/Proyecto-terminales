using System;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaCompañia : IPersistenciaCompañia
    {
        //singleton
        private static PersistenciaCompañia _instancia = null;
        private PersistenciaCompañia() { }

        public static PersistenciaCompañia GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCompañia();
            return _instancia;
        }//fin singleton
        public Compañia Buscar(string unaC)
        {
            string _nombre;
            string _direccion;
            int _tel;
            Compañia C = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarCompañia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter _pNombre = new SqlParameter("@Nombre", unaC);
            oComando.Parameters.Add(_pNombre);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    oReader.Read();
                    _nombre = (string)oReader["Nombre"];
                    _direccion = (string)oReader["Direccion"];
                    _tel = (int)oReader["Tel"];
                    C = new Compañia(_nombre,_direccion,_tel);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return C;
        }
        public void Alta(Compañia unaC)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaCompañia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@Nombre", unaC.Nombre);
            SqlParameter _direccion = new SqlParameter("@Direccion", unaC.Direccion);
            SqlParameter _tel = new SqlParameter("@Tel", unaC.Tel);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_direccion);
            oComando.Parameters.Add(_tel);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La compañia ya existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
