using System;
using System.Collections.Generic;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaViaje : IPersistenciaViaje
    {
        //singleton
        private static PersistenciaViaje _instancia = null;
        private PersistenciaViaje() { }

        public static PersistenciaViaje GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaViaje();
            return _instancia;
        }//fin singleton
        public void AltaViaje(Viaje UnV)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaViaje", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@FechaHoraP", UnV.FechaHoraP);
            oComando.Parameters.AddWithValue("@FechaHoraD", UnV.FechaHoraD);
            oComando.Parameters.AddWithValue("@MaxPasajeros", UnV.MaxPasajeros);
            oComando.Parameters.AddWithValue("@Precio", UnV.Precio);
            oComando.Parameters.AddWithValue("@Anden ", UnV.Anden);
            oComando.Parameters.AddWithValue("@UsuLogueo", UnV.UnEmp.Usuario); 
            oComando.Parameters.AddWithValue("@NomCompañia ", UnV.UnaComp.Nombre);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_ParmRetorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                oConexion.Open();
                _miTransaccion = oConexion.BeginTransaction();
                oComando.Transaction = _miTransaccion;
                oComando.ExecuteNonQuery();

                int oAfectados = Convert.ToInt32(_ParmRetorno.Value);

                if (oAfectados == -2)
                    throw new Exception("El Empleado debe existir");
                else if (oAfectados == -3)
                    throw new Exception("La Compañia debe existir");
                else if (oAfectados == -4)
                    throw new Exception("La hora de partida debe tener al menos una diferencia de 10 minutos con respecto a otros viajes.");
                foreach (PasaPor unaT in UnV.Coleccion)
                {
                    PersistenciaPasaPor.GetInstance().AltaPPViaje(unaT,oAfectados, _miTransaccion);
                }

                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }
        public List<Viaje> ListadoViajes()
        {
            int _codigo;
            DateTime _fechaHoraP;
            DateTime _fechaHoraD;
            int _maxPasajeros;
            decimal _precio;
            int _anden;
            string _usuEmp;        
            string _nomComp;
            List<Viaje> _Lista = new List<Viaje>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("ListadoViajes", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        _codigo = (int)_Reader["Codigo"];
                        _fechaHoraP = (DateTime)_Reader["FechaHoraP"];
                        _fechaHoraD = (DateTime)_Reader["FechaHoraD"];
                        _maxPasajeros = (int)_Reader["MaxPasajeros"];
                        _precio = (decimal)_Reader["Precio"];
                        _anden = (int)_Reader["Anden"];
                        _usuEmp = (string)_Reader["UsuLogueo"];
                        _nomComp = (string)_Reader["NomCompañia"];
                        Compañia _unaComp = PersistenciaCompañia.GetInstance().Buscar(_nomComp);
                        Empleado _unEmp = PersistenciaEmpleado.GetInstance().Buscar(_usuEmp);
                        Viaje V = new Viaje(_codigo, _fechaHoraP, _fechaHoraD, _maxPasajeros, _precio,
                                  _anden, PersistenciaPasaPor.GetInstance().ListTerViaje(_codigo), _unEmp, _unaComp);
                        _Lista.Add(V);
                    }
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return  _Lista;
        }
        public List<Viaje> ListadoViajesAM() 
        {
            int _codigo;
            DateTime _fechaHoraP;
            DateTime _fechaHoraD;
            int _maxPasajeros;
            decimal _precio;
            int _anden;
            string _usuEmp;
            string _nomComp;
            List<Viaje> _Lista = new List<Viaje>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("ListadoViajesAM", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        _codigo = (int)_Reader["Codigo"];
                        _fechaHoraP = (DateTime)_Reader["FechaHoraP"];
                        _fechaHoraD = (DateTime)_Reader["FechaHoraD"];
                        _maxPasajeros = (int)_Reader["MaxPasajeros"];
                        _precio = (decimal)_Reader["Precio"];
                        _anden = (int)_Reader["Anden"];
                        _usuEmp = (string)_Reader["UsuLogueo"];
                        _nomComp = (string)_Reader["NomCompañia"];
                        Compañia _unaComp = PersistenciaCompañia.GetInstance().Buscar(_nomComp);
                        Empleado _unEmp = PersistenciaEmpleado.GetInstance().Buscar(_usuEmp);
                        Viaje V = new Viaje(_codigo, _fechaHoraP, _fechaHoraD, _maxPasajeros, _precio,
                                  _anden, PersistenciaPasaPor.GetInstance().ListTerViaje(_codigo), _unEmp, _unaComp);
                        _Lista.Add(V);
                    }
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }
    }
}
