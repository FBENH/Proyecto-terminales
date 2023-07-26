using System;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaInternacional :IPersistenciaInternacional
    {
        //singleton
        private static PersistenciaInternacional _instancia = null;
        private PersistenciaInternacional() { }

        public static PersistenciaInternacional GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaInternacional();
            return _instancia;
        }//fin singleton

        public Internacional BuscarTAI(string TIActiva)
        {
            Internacional I = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarTerActivasI", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;            
            SqlParameter _pCodigo = new SqlParameter("@Codigo", TIActiva);
            oComando.Parameters.Add(_pCodigo);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    oReader.Read();
                    string _codigo = (string)oReader["Codigo"];
                    string _ciudad = (string)oReader["Ciudad"];
                    string _pais = (string)oReader["Pais"];
                    I = new Internacional(_codigo,_ciudad,_pais);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return I;
        }
        internal Internacional BuscarTI(string unaTi)
        {
            Internacional I = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarTerTodasI", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter _pCodigo = new SqlParameter("@Codigo", unaTi);
            oComando.Parameters.Add(_pCodigo);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    oReader.Read();
                    string _codigo = (string)oReader["Codigo"];
                    string _ciudad = (string)oReader["Ciudad"];
                    string _pais = (string)oReader["Pais"];
                    I = new Internacional(_codigo, _ciudad, _pais);
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
            return I;
        }
        public void Alta(Internacional unaTi)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaTerminalInt", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unaTi.Codigo);
            SqlParameter _ciudad = new SqlParameter("@Ciudad", unaTi.Ciudad);
            SqlParameter _pais = new SqlParameter("@Pais", unaTi.Pais);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_ciudad);
            oComando.Parameters.Add(_pais);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La terminal ya existe");
                if (oAfectados == -2)
                    throw new Exception("Error en la base de datos");
                if (oAfectados == -3)
                    throw new Exception("La terminal ya existe y es nacional, no se puede dar de alta");
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
        public void Modificar(Internacional unaTi)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ModificarTerminalInt", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unaTi.Codigo);
            SqlParameter _ciudad = new SqlParameter("@Ciudad", unaTi.Ciudad);
            SqlParameter _pais = new SqlParameter("@Pais", unaTi.Pais);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_ciudad);
            oComando.Parameters.Add(_pais);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La terminal ingresada no existe");
                if (oAfectados == -2)
                    throw new Exception("Error en la base de datos");
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
        public void Baja(Internacional unaTi)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BajaTerminalInt", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unaTi.Codigo);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La terminal no existe");
                if (oAfectados == -2)
                    throw new Exception("Error en la base de datos");

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
