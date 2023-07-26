using System;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaEmpleado : IPersistenciaEmpleado
    {
        //singleton
        private static PersistenciaEmpleado _instancia = null;
        private PersistenciaEmpleado() { }

        public static PersistenciaEmpleado GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaEmpleado();
            return _instancia;
        }//fin singleton
        public Empleado Logueo(string pUsu, string pPass)
        {
            Empleado E = null;
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("Logueo", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@usu", pUsu);
            _Comando.Parameters.AddWithValue("@pass", pPass);

            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.HasRows)
                {
                    _Reader.Read();
                    E = new Empleado((string)_Reader["Usuario"], (string)_Reader["Pass"], (string)_Reader["NomCompleto"]);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return E;
        }
        public Empleado Buscar(string unE)
        {
            Empleado E = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter _pUsuario = new SqlParameter("@Usuario", unE);
            oComando.Parameters.Add(_pUsuario);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    oReader.Read();
                    string _usuario = (string)oReader["Usuario"];
                    string _pass = (string)oReader["Pass"];
                    string _nomCompleto = (string)oReader["NomCompleto"];
                    E = new Empleado(_pass,_usuario,_nomCompleto);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return E;
        }
        public void Alta(Empleado unE)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _usu = new SqlParameter("@Usuario", unE.Usuario);
            SqlParameter _pass = new SqlParameter("@Pass", unE.Pass);
            SqlParameter _nomCompleto = new SqlParameter("@NomCompleto", unE.NomCompleto);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_usu);
            oComando.Parameters.Add(_pass);
            oComando.Parameters.Add(_nomCompleto);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El usuario ya existe");
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
