using System;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaNacional :IPersistenciaNacional
    {
        //singleton
        private static PersistenciaNacional _instancia = null;
        private PersistenciaNacional() { }

        public static PersistenciaNacional GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaNacional();
            return _instancia;
        }//fin singleton
        public Nacional BuscarTAN(string unaTN)
        {
            Nacional N = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarTerActivasN", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter _pCodigo = new SqlParameter("@Codigo", unaTN);
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
                    bool _taxi = (bool)oReader["Taxi"];
                    N = new Nacional(_codigo, _ciudad, _taxi);
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
            return N;
        }
        internal Nacional BuscarTN(string unaTN)
        {
            Nacional N = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarTerTodasN", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter _pCodigo = new SqlParameter("@Codigo", unaTN);
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
                    bool _taxi = (bool)oReader["Taxi"];
                    N = new Nacional(_codigo, _ciudad, _taxi);
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
            return N;
        }
        public void Alta(Nacional unaTN)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaTerminalNac", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unaTN.Codigo);
            SqlParameter _ciudad = new SqlParameter("@Ciudad", unaTN.Ciudad);
            SqlParameter _taxi = new SqlParameter("@Taxi", unaTN.Taxi);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_ciudad);
            oComando.Parameters.Add(_taxi);
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
                    throw new Exception("La terminal ya existe y es internacional, no se puede dar de alta");
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
        public void Modificar(Nacional unaTN)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ModificarTerminalNac", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unaTN.Codigo);
            SqlParameter _ciudad = new SqlParameter("@Ciudad", unaTN.Ciudad);
            SqlParameter _taxi = new SqlParameter("@Taxi", unaTN.Taxi);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_ciudad);
            oComando.Parameters.Add(_taxi);
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
        public void Baja(Nacional unaTN)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BajaTerminalNac", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unaTN.Codigo);
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
